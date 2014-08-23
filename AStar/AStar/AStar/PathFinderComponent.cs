using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;

namespace AStar
{
    /// <summary>
    /// Defines a node
    /// </summary>
    class PathNode
    {
        /// <summary>
        /// Node position
        /// </summary>
        public Vector2 nodePos;

        /// <summary>
        /// Parent node
        /// </summary>
        public PathNode parentNode;

        /// <summary>
        /// Value F (G + H)
        /// </summary>
        public float valueF;

        /// <summary>
        /// Value G (total distance)
        /// </summary>
        public float valueG;

        /// <summary>
        /// Heuristic
        /// </summary>
        public float valueH;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nodePos">Node position</param>
        /// <param name="targetPos">Target position</param>
        /// <param name="parentNode">Parent node</param>
        public PathNode(Vector2 nodePos, Vector2 targetPos, PathNode parentNode)
        {
            this.nodePos = nodePos;
            this.parentNode = parentNode;

            if (this.parentNode != null)
                this.valueG = this.parentNode.valueG + (nodePos - this.parentNode.nodePos).Length();
            else
                this.valueG = 0.0f;

            this.valueH = Math.Abs(targetPos.X - nodePos.X) + Math.Abs(targetPos.Y - nodePos.Y);

            this.valueF = this.valueG + this.valueH;
        }
    }

    /// <summary>
    /// A* path finding component
    /// </summary>
    class PathFinderComponent
    {
        /// <summary>
        /// Level grid data
        /// </summary>
        bool[,] levelGrid;

        /// <summary>
        /// Open list
        /// </summary>
        List<PathNode> openList;

        /// <summary>
        /// Closed list
        /// </summary>
        List<PathNode> closedList;

        /// <summary>
        /// List of next nodes
        /// </summary>
        List<Vector2> nextNodes;

        /// <summary>
        /// Current pos
        /// </summary>
        Vector2 currentPos;

        /// <summary>
        /// Target pos
        /// </summary>
        Vector2 targetPos;

        /// <summary>
        /// Ture if path finder is currently resetting
        /// </summary>
        bool resetPathFinder = false;

        /// <summary>
        /// Thread for path finding
        /// </summary>
        Thread pathFindingThread;

        /// <summary>
        /// Lock for nextNodes lock
        /// </summary>
        object nextNodexLock = new object();

        /// <summary>
        /// Is pather finder currently searching path?
        /// </summary>
        public bool currentlySearching = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startPos">Start pos</param>
        /// <param name="targetPos">Target pos</param>
        public PathFinderComponent(Vector2 startPos, Vector2 targetPos, bool[,] levelGrid)
        {
            this.levelGrid = levelGrid;
            this.ResetPath(startPos, targetPos);
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~PathFinderComponent()
        {
            this.resetPathFinder = true;
            this.pathFindingThread.Abort();
        }

        /// <summary>
        /// Reset/recalculate path
        /// </summary>
        void ResetPath(Vector2 startPos, Vector2 targetPos)
        {
            this.resetPathFinder = true;

            if (this.pathFindingThread != null && this.pathFindingThread.ThreadState == ThreadState.Running)
                this.pathFindingThread.Join();

            this.currentPos = startPos;
            this.targetPos = targetPos;

            this.openList = new List<PathNode>();
            this.openList.Add(new PathNode(startPos, this.targetPos, null));

            this.closedList = new List<PathNode>();

            this.resetPathFinder = false;

            this.pathFindingThread = new Thread(this.FindPath);
            this.pathFindingThread.Name = "Path Finder Thread";
            this.pathFindingThread.Start();
        }

        /// <summary>
        /// Find shortest path to target position
        /// </summary>
        void FindPath()
        {
            PathNode currentNode = null;
            this.currentlySearching = true;

            while (!(this.resetPathFinder) && this.openList.Count > 0 && !(currentNode != null && currentNode.nodePos == this.targetPos))
            {
                // Find node with lowest F value
                currentNode = this.openList[0];
                foreach (PathNode openNode in this.openList)
                {
                    if (openNode.valueF <= currentNode.valueF)
                        currentNode = openNode;
                }

                this.closedList.Add(currentNode);
                this.openList.Remove(currentNode);

                // Inspect surrounding nodes
                Vector2 nextPos = currentNode.nodePos + new Vector2(-1.0f, -1.0f);
                PathNode pathNode = new PathNode(nextPos, this.targetPos, currentNode);
                PathNode[] additionalNodes = new PathNode[]
                {
                    new PathNode(currentNode.nodePos + new Vector2(-1.0f, 0.0f), this.targetPos, currentNode),
                    new PathNode(currentNode.nodePos + new Vector2(0.0f, -1.0f), this.targetPos, currentNode)
                };
                this.UpdateNode(pathNode, currentNode, additionalNodes);

                nextPos = currentNode.nodePos + new Vector2(0.0f, -1.0f);
                pathNode = new PathNode(nextPos, this.targetPos, currentNode);
                this.UpdateNode(pathNode, currentNode, null);

                nextPos = currentNode.nodePos + new Vector2(1.0f, -1.0f);
                pathNode = new PathNode(nextPos, this.targetPos, currentNode);
                additionalNodes = new PathNode[]
                {
                    new PathNode(currentNode.nodePos + new Vector2(1.0f, 0.0f), this.targetPos, currentNode),
                    new PathNode(currentNode.nodePos + new Vector2(0.0f, -1.0f), this.targetPos, currentNode)
                };
                this.UpdateNode(pathNode, currentNode, additionalNodes);

                nextPos = currentNode.nodePos + new Vector2(1.0f, 0.0f);
                pathNode = new PathNode(nextPos, this.targetPos, currentNode);
                this.UpdateNode(pathNode, currentNode, null);

                nextPos = currentNode.nodePos + new Vector2(1.0f, 1.0f);
                pathNode = new PathNode(nextPos, this.targetPos, currentNode);
                additionalNodes = new PathNode[]
                {
                    new PathNode(currentNode.nodePos + new Vector2(1.0f, 0.0f), this.targetPos, currentNode),
                    new PathNode(currentNode.nodePos + new Vector2(0.0f, 1.0f), this.targetPos, currentNode)
                };
                this.UpdateNode(pathNode, currentNode, additionalNodes);

                nextPos = currentNode.nodePos + new Vector2(0.0f, 1.0f);
                pathNode = new PathNode(nextPos, this.targetPos, currentNode);
                this.UpdateNode(pathNode, currentNode, null);

                nextPos = currentNode.nodePos + new Vector2(-1.0f, 1.0f);
                pathNode = new PathNode(nextPos, this.targetPos, currentNode);
                additionalNodes = new PathNode[]
                {
                    new PathNode(currentNode.nodePos + new Vector2(-1.0f, 0.0f), this.targetPos, currentNode),
                    new PathNode(currentNode.nodePos + new Vector2(0.0f, 1.0f), this.targetPos, currentNode)
                };
                this.UpdateNode(pathNode, currentNode, additionalNodes);

                nextPos = currentNode.nodePos + new Vector2(-1.0f, 0.0f);
                pathNode = new PathNode(nextPos, this.targetPos, currentNode);
                this.UpdateNode(pathNode, currentNode, null);
            }

            // Reached target pos, so trace back path
            lock (this.nextNodexLock)
            {
                this.nextNodes = new List<Vector2>();

                if (currentNode != null && currentNode.nodePos == this.targetPos)
                {
                    this.nextNodes.Add(currentNode.nodePos);

                    while (currentNode.parentNode != null)
                    {
                        currentNode = currentNode.parentNode;
                        this.nextNodes.Insert(0, currentNode.nodePos);
                    }
                }
            }

            this.currentlySearching = false;
        }

        /// <summary>
        /// Update information on a node and add it to open list if necessary
        /// </summary>
        /// <param name="pathNode">The node to update</param>
        /// <param name="checkedNode">The currently selected node</param>
        void UpdateNode(PathNode pathNode, PathNode checkedNode, PathNode[] additionalNodes)
        {
            if (this.CheckNodePassability(pathNode, additionalNodes))
            {
                PathNode openNode = this.OnOpenList(pathNode);
                if (openNode != null)
                {
                    pathNode = openNode;
                    float newValueG = checkedNode.valueG + (pathNode.nodePos - checkedNode.nodePos).Length();
                    if (newValueG < pathNode.valueG)
                    {
                        pathNode.valueG = newValueG;
                        pathNode.valueF = pathNode.valueG + pathNode.valueH;
                        pathNode.parentNode = checkedNode;
                    }

                }
                else if (!(this.OnClosedList(pathNode)))
                    this.openList.Add(pathNode);
            }
        }

        /// <summary>
        /// Check if a node is passable
        /// </summary>
        /// <param name="pathNode">Main node to check</param>
        /// <param name="additionalNodes">Additional nodes to check</param>
        /// <returns>True if node passable</returns>
        bool CheckNodePassability(PathNode pathNode, PathNode[] additionalNodes)
        {
            bool nodePassable = this.PointInBounds(pathNode.nodePos) && !(this.levelGrid[(int)(pathNode.nodePos.X), (int)(pathNode.nodePos.Y)]);

            if (nodePassable && additionalNodes != null)
            {
                for (int i = 0; i < additionalNodes.Length && nodePassable; i++)
                    nodePassable = this.PointInBounds(additionalNodes[i].nodePos) && !(this.levelGrid[(int)(additionalNodes[i].nodePos.X), (int)(additionalNodes[i].nodePos.Y)]);
            }

            return nodePassable;
        }

        /// <summary>
        /// Check if a path node is already on open list
        /// </summary>
        /// <param name="pathNode">Path node to check</param>
        /// <returns>Path node if found in list or null otherwise</returns>
        PathNode OnOpenList(PathNode pathNode)
        {
            foreach(PathNode currentNode in this.openList)
            {
                if (currentNode.nodePos == pathNode.nodePos)
                    return currentNode;
            }

            return null;
        }

        /// <summary>
        /// Check if a path node is already on closed list
        /// </summary>
        /// <param name="pathNode">Path node to check</param>
        /// <returns>True if on closed list</returns>
        bool OnClosedList(PathNode pathNode)
        {
            foreach (PathNode currentNode in this.closedList)
            {
                if (currentNode.nodePos == pathNode.nodePos)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Check if a point lies within the bounds of the level
        /// </summary>
        /// <param name="referencePos">The point to check</param>
        /// <returns>True if point lies inside level</returns>
        bool PointInBounds(Vector2 referencePos)
        {
            if (referencePos.X >= 0 && referencePos.Y >= 0 && referencePos.X < this.levelGrid.GetLength(0) && referencePos.Y < this.levelGrid.GetLength(1))
                return true;

            return false;
        }

        /// <summary>
        /// Set target position
        /// </summary>
        /// <param name="targetPos">Target position</param>
        public void SetTargetPos(Vector2 targetPos)
        {
            if (this.targetPos != targetPos)
            {
                this.targetPos = targetPos;
                this.ResetPath(this.currentPos, targetPos);
            }
        }

        /// <summary>
        /// Notify path finder that level grid was updated and path has to be recalculated
        /// </summary>
        public void UpdatedLevelGrid()
        {
            this.ResetPath(this.currentPos, targetPos);
        }

        /// <summary>
        /// Get next nodes on path
        /// </summary>
        /// <param name="currentPos">The current position</param>
        /// <returns>Next nodes</returns>
        public List<Vector2> GetNextNodes(Vector2 currentPos)
        {
            List<Vector2> copyList;

            lock (this.nextNodexLock)
            {
                if (this.nextNodes.Count > 0 && new Vector2((float)(Math.Round(currentPos.X)), (float)(Math.Round(currentPos.Y))) == this.nextNodes[0])
                {
                    this.nextNodes.RemoveAt(0);

                    if (this.nextNodes.Count > 0)
                        this.currentPos = this.nextNodes[0];
                }

                copyList = new List<Vector2>(this.nextNodes);
            }

            return copyList;
        }
    }
}
