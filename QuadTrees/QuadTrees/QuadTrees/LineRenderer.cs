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
    static class LineRenderer
    {
        /// <summary>
        /// Draw a line between two points
        /// </summary>
        /// <param name="batch">SpriteBatch to draw onto</param>
        /// <param name="width">Line width</param>
        /// <param name="blankTexture">A blank texture</param>
        /// <param name="color">Line color</param>
        /// <param name="point1">Point 1</param>
        /// <param name="point2">Point 2</param>
        public static void DrawLine(SpriteBatch batch, Texture2D blankTexture, float width, Color color, Vector2 point1, Vector2 point2)
        {
            float angle = (float)(Math.Atan2(point2.Y - point1.Y, point2.X - point1.X));
            float length = Vector2.Distance(point1, point2);

            point1.X += width * (float)(Math.Sin(angle)) / 2.0f;
            point1.Y -= width * (float)(Math.Cos(angle)) / 2.0f;

            batch.Draw(blankTexture, point1, null, color, angle, Vector2.Zero, new Vector2(length, width), SpriteEffects.None, 0);
        }
    }
}
