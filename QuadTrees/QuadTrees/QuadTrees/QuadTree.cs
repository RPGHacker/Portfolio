using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace QuadTrees
{
    /// <summary>
    /// Interface for quad tree elements
    /// </summary>
    public interface IQuadTreeElement
    {
        /// <summary>
        /// Element's bounding box
        /// </summary>
        Rectangle boundingBox { get;set; }
    }


    /// <summary>
    /// Quad tree class
    /// </summary>
    public class QuadTree
    {
        /// <summary>
        /// Dimensions start
        /// </summary>
        private Vector2 dimensionsFrom;

        /// <summary>
        /// Dimensions end
        /// </summary>
        private Vector2 dimensionsTo;

        /// <summary>
        /// Max tree depth
        /// </summary>
        private int maxDepth;

        /// <summary>
        /// Current tree depth
        /// </summary>
        private int currentDepth;

        /// <summary>
        /// Tree's first quad
        /// </summary>
        private QuadTree quadOne = null;

        /// <summary>
        /// Tree's second quad
        /// </summary>
        private QuadTree quadTwo = null;

        /// <summary>
        /// Tree's third quad
        /// </summary>
        private QuadTree quadThree = null;

        /// <summary>
        /// Tree's fourth quad
        /// </summary>
        private QuadTree quadFour = null;

        /// <summary>
        /// List of elements in this quad
        /// </summary>
        private List<IQuadTreeElement> elements = new List<IQuadTreeElement>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dimensionsFrom">Dimensions start</param>
        /// <param name="dimensionsTo">Dimensions end</param>
        /// <param name="maxDepth">Max depth</param>
        public QuadTree(Vector2 dimensionsFrom, Vector2 dimensionsTo, int maxDepth)
        {
            this.dimensionsFrom = dimensionsFrom;
            this.dimensionsTo = dimensionsTo;
            this.maxDepth = maxDepth;
            this.currentDepth = 0;

            this.SwapBorders();
        }

        /// <summary>
        /// Private constructor
        /// </summary>
        /// <param name="dimensionsFrom">Dimensions start</param>
        /// <param name="dimensionsTo">Dimensions end</param>
        /// <param name="currentDepth">The current depth</param>
        /// <param name="maxDepth">Max depth</param>
        private QuadTree(Vector2 dimensionsFrom, Vector2 dimensionsTo, int currentDepth, int maxDepth)
        {
            this.dimensionsFrom = dimensionsFrom;
            this.dimensionsTo = dimensionsTo;
            this.maxDepth = maxDepth;
            this.currentDepth = currentDepth;

            this.SwapBorders();
        }

        /// <summary>
        /// Swap borders if necessary
        /// </summary>
        private void SwapBorders()
        {
            if (this.dimensionsFrom.X > this.dimensionsTo.X)
            {
                float temp = this.dimensionsTo.X;
                this.dimensionsTo.X = this.dimensionsFrom.X;
                this.dimensionsFrom.X = temp;
            }

            if (this.dimensionsFrom.Y > this.dimensionsTo.Y)
            {
                float temp = this.dimensionsTo.Y;
                this.dimensionsTo.Y = this.dimensionsFrom.Y;
                this.dimensionsFrom.Y = temp;
            }
        }

        /// <summary>
        /// Insert element into quad tree
        /// </summary>
        /// <param name="element">Element to insert into quad tree</param>
        public void InsertElement(IQuadTreeElement element)
        {
            // Max depth reached?
            if (this.currentDepth >= this.maxDepth)
            {
                elements.Add(element);
                return;
            }


            // Which quads is element in?
            Vector2 center = (dimensionsFrom + dimensionsTo) / 2.0f;

            int quadCount = 0;
            bool inQuadOne = false;
            bool inQuadTwo = false;
            bool inQuadThree = false;
            bool inQuadFour = false;

            if (element.boundingBox.X < center.X && element.boundingBox.Y < center.Y &&
                element.boundingBox.X + element.boundingBox.Width >= this.dimensionsFrom.X && element.boundingBox.Y + element.boundingBox.Height >= this.dimensionsFrom.Y)
            {
                inQuadOne = true;
                quadCount++;
            }

            if (element.boundingBox.X + element.boundingBox.Width >= center.X && element.boundingBox.Y < center.Y &&
                element.boundingBox.X < this.dimensionsTo.X && element.boundingBox.Y + element.boundingBox.Height >= this.dimensionsFrom.Y)
            {
                inQuadTwo = true;
                quadCount++;
            }

            if (element.boundingBox.X < center.X && element.boundingBox.Y + element.boundingBox.Height >= center.Y &&
                element.boundingBox.X + element.boundingBox.Width >= this.dimensionsFrom.X && element.boundingBox.Y < this.dimensionsTo.Y)
            {
                inQuadThree = true;
                quadCount++;
            }

            if (element.boundingBox.X + element.boundingBox.Width >= center.X && element.boundingBox.Y + element.boundingBox.Height >= center.Y &&
                element.boundingBox.X < this.dimensionsTo.X && element.boundingBox.Y < this.dimensionsTo.Y)
            {
                inQuadFour = true;
                quadCount++;
            }


            // Element is in no quad
            if (quadCount == 0)
                throw new ArgumentException("The element lies outside the tree", "element");


            // Element is in multiple quads
            if (quadCount > 1)
            {
                elements.Add(element);
                return;
            }


            // Element is in a specific quad
            if (inQuadOne)
            {
                if (this.quadOne == null)
                    this.quadOne = new QuadTree(this.dimensionsFrom, center, this.currentDepth + 1, this.maxDepth);

                this.quadOne.InsertElement(element);
            }

            if (inQuadTwo)
            {
                if (this.quadTwo == null)
                    this.quadTwo = new QuadTree(center, new Vector2(this.dimensionsTo.X, this.dimensionsFrom.Y), this.currentDepth + 1, this.maxDepth);

                this.quadTwo.InsertElement(element);
            }

            if (inQuadThree)
            {
                if (this.quadThree == null)
                    this.quadThree = new QuadTree(new Vector2(this.dimensionsFrom.X, this.dimensionsTo.Y), center, this.currentDepth + 1, this.maxDepth);

                this.quadThree.InsertElement(element);
            }

            if (inQuadFour)
            {
                if (this.quadFour == null)
                    this.quadFour = new QuadTree(center, new Vector2(this.dimensionsTo.X, this.dimensionsTo.Y), this.currentDepth + 1, this.maxDepth);

                this.quadFour.InsertElement(element);
            }
        }

        /// <summary>
        /// Query all elements from this quad tree lying inside a circle
        /// </summary>
        /// <param name="center">Center of circle</param>
        /// <param name="radius">Radius of circle</param>
        /// <returns>List of elements in circle</returns>
        public List<IQuadTreeElement> ElementsInCircle(Vector2 center, float radius)
        {
            List<IQuadTreeElement> newList = new List<IQuadTreeElement>();

            BoundingSphere boundingSphere = new BoundingSphere(new Vector3(center.X, center.Y, 0), radius);
            BoundingBox boundingBox;

            // Check all elements in current quad
            for (int i = 0; i < this.elements.Count; i++)
            {
                boundingBox = new BoundingBox(new Vector3(this.elements[i].boundingBox.X, this.elements[i].boundingBox.Y, -1), new Vector3(this.elements[i].boundingBox.X + this.elements[i].boundingBox.Width, this.elements[i].boundingBox.Y + this.elements[i].boundingBox.Height, +1));
                if (boundingSphere.Intersects(boundingBox))
                    newList.Add(this.elements[i]);
            }

            // If circle intersects with quad 1, check all elements in quad 1
            if (this.quadOne != null)
            {
                boundingBox = new BoundingBox(new Vector3(this.quadOne.dimensionsFrom.X, this.quadOne.dimensionsFrom.Y, -1), new Vector3(this.quadOne.dimensionsTo.X, this.quadOne.dimensionsTo.Y, +1));
                if (boundingSphere.Intersects(boundingBox))
                    newList.AddRange(this.quadOne.ElementsInCircle(center, radius));
            }

            // If circle intersects with quad 2, check all elements in quad 1
            if (this.quadTwo != null)
            {
                boundingBox = new BoundingBox(new Vector3(this.quadTwo.dimensionsFrom.X, this.quadTwo.dimensionsFrom.Y, -1), new Vector3(this.quadTwo.dimensionsTo.X, this.quadTwo.dimensionsTo.Y, +1));
                if (boundingSphere.Intersects(boundingBox))
                    newList.AddRange(this.quadTwo.ElementsInCircle(center, radius));
            }

            // If circle intersects with quad 3, check all elements in quad 1
            if (this.quadThree != null)
            {
                boundingBox = new BoundingBox(new Vector3(this.quadThree.dimensionsFrom.X, this.quadThree.dimensionsFrom.Y, -1), new Vector3(this.quadThree.dimensionsTo.X, this.quadThree.dimensionsTo.Y, +1));
                if (boundingSphere.Intersects(boundingBox))
                    newList.AddRange(this.quadThree.ElementsInCircle(center, radius));
            }

            // If circle intersects with quad 4, check all elements in quad 1
            if (this.quadFour != null)
            {
                boundingBox = new BoundingBox(new Vector3(this.quadFour.dimensionsFrom.X, this.quadFour.dimensionsFrom.Y, -1), new Vector3(this.quadFour.dimensionsTo.X, this.quadFour.dimensionsTo.Y, +1));
                if (boundingSphere.Intersects(boundingBox))
                    newList.AddRange(this.quadFour.ElementsInCircle(center, radius));
            }                

            return newList;
        }


        /// <summary>
        /// Expand quad tree by inserting it into a new quad tree four times in size
        /// </summary>
        /// <param name="negativeX">Expand into negative X space?</param>
        /// <param name="negativeY">Expand into negative Y space?</param>
        /// <returns>Returns new expanded quad tree</returns>
        public QuadTree ExpandQuadTree(bool negativeX, bool negativeY)
        {
            this.RaiseDepth();

            Vector2 size = this.dimensionsTo - this.dimensionsFrom;
            Vector2 dimensionsFrom;
            Vector2 dimensionsTo;

            // Calculate new dimensions
            if (negativeX)
            {
                dimensionsFrom.X = this.dimensionsFrom.X - size.X;
                dimensionsTo.X = this.dimensionsTo.X;
            }
            else
            {
                dimensionsFrom.X = this.dimensionsFrom.X;
                dimensionsTo.X = this.dimensionsTo.X + size.X;
            }

            if (negativeY)
            {
                dimensionsFrom.Y = this.dimensionsFrom.Y - size.Y;
                dimensionsTo.Y = this.dimensionsTo.Y;
            }
            else
            {
                dimensionsFrom.Y = this.dimensionsFrom.Y;
                dimensionsTo.Y = this.dimensionsTo.Y + size.Y;
            }

            // Create new tree and insert current tree into it
            QuadTree newTree = new QuadTree(dimensionsFrom, dimensionsTo, this.maxDepth);

            if (!negativeX && !negativeY)
                newTree.quadOne = this;

            if (negativeX && !negativeY)
                newTree.quadTwo = this;

            if (!negativeX && negativeY)
                newTree.quadThree = this;

            if (negativeX && negativeY)
                newTree.quadFour = this;

            return newTree;
        }

        /// <summary>
        /// Raise a quad tree's depth and max depth by 1
        /// </summary>
        private void RaiseDepth()
        {
            this.currentDepth += 1;
            this.maxDepth += 1;

            if (this.quadOne != null)
                this.quadOne.RaiseDepth();
            if (this.quadTwo != null)
                this.quadTwo.RaiseDepth();
            if (this.quadThree != null)
                this.quadThree.RaiseDepth();
            if (this.quadFour != null)
                this.quadFour.RaiseDepth();
        }


        /// <summary>
        /// Draw the quad tree
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw onto</param>
        /// <param name="blankTexture">Blank texture</param>
        public void DrawTree(SpriteBatch spriteBatch, Texture2D blankTexture)
        {
            if (this.quadOne != null)
                this.quadOne.DrawTree(spriteBatch, blankTexture);

            if (this.quadTwo != null)
                this.quadTwo.DrawTree(spriteBatch, blankTexture);

            if (this.quadThree != null)
                this.quadThree.DrawTree(spriteBatch, blankTexture);

            if (this.quadFour != null)
                this.quadFour.DrawTree(spriteBatch, blankTexture);

            // Draw borders
            LineRenderer.DrawLine(spriteBatch, blankTexture, 2, Color.Red, this.dimensionsFrom, new Vector2(this.dimensionsTo.X, this.dimensionsFrom.Y));
            LineRenderer.DrawLine(spriteBatch, blankTexture, 2, Color.Red, new Vector2(this.dimensionsTo.X, this.dimensionsFrom.Y), this.dimensionsTo);
            LineRenderer.DrawLine(spriteBatch, blankTexture, 2, Color.Red, this.dimensionsTo, new Vector2(this.dimensionsFrom.X, this.dimensionsTo.Y));
            LineRenderer.DrawLine(spriteBatch, blankTexture, 2, Color.Red, new Vector2(this.dimensionsFrom.X, this.dimensionsTo.Y), this.dimensionsFrom);

            // Draw elements
            foreach (IQuadTreeElement element in this.elements)
                spriteBatch.Draw(blankTexture, element.boundingBox, Color.Green);
        }
    }
}
