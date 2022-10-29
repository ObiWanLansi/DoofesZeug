using System;
using System.Collections.Generic;

using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Datatypes.Graph
{

    public enum Direction : byte
    {
        NoDirection,
        SourceToDestination,
        DestiantionToSource,
        BiDirectional

    } // end public enum Direction



    /// <summary>
    /// Rudimentäre Unterstüzung zur Erzeugung von kleinen Graphen 
    /// sowie Export in GraphML Dateien primär zum öffnen mit YED.
    /// </summary>
    public sealed class Graph
    {
        /// <summary>
        /// The sd nodes
        /// </summary>
        private readonly SortedDictionary<string, Node> sdNodes = new();

        /// <summary>
        /// The sd edges
        /// </summary>
        private readonly SortedDictionary<string, Edge> sdEdges = new();

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the default direction.
        /// </summary>
        /// <value>
        /// The default direction.
        /// </value>
        public Direction? DefaultDirection { get; set; }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        /// <value>
        /// The properties.
        /// </value>
        public SimpleProperties Properties { get; set; } = new();

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        #region Node Operations

        /// <summary>
        /// Gets the nodes.
        /// </summary>
        /// <value>
        /// The nodes.
        /// </value>
        public Node[] Nodes => new List<Node>(this.sdNodes.Values).ToArray();


        /// <summary>
        /// Clears the nodes.
        /// </summary>
        public void ClearNodes()
        {
            this.sdNodes.Clear();

            // Wenn alle Nodes gelöscht werden, müssen natürlich auch alle Verbdinungen gelöscht werden.
            this.sdEdges.Clear();
        }


        /// <summary>
        /// Adds the node.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public bool AddNode(Node n)
        {
            if (this.sdNodes.ContainsKey(n.Id) == false)
            {
                this.sdNodes.Add(n.Id, n);
                return true;
            }

            return false;
        }


        /// <summary>
        /// Adds the nodes.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        /// <returns></returns>
        public bool AddNodes(params Node[] nodes)
        {
            bool bNoError = true;

            foreach (Node n in nodes)
            {
                // Wenn ein Knoten nicht hinzugefügt werden kann wird false zurückgeliefert.
                if (this.sdNodes.ContainsKey(n.Id) == false)
                {
                    this.sdNodes.Add(n.Id, n);
                }
                else
                {
                    bNoError = false;
                }
            }

            return bNoError;
        }


        /// <summary>
        /// Adds the nodes.
        /// </summary>
        /// <param name="nodes">The l nodes.</param>
        /// <returns></returns>
        public bool AddNodes(IEnumerable<Node> nodes)
        {
            bool bNoError = true;

            foreach (Node n in nodes)
            {
                // Wenn ein Knoten nicht hinzugefügt werden kann wird false zurückgeliefert.
                if (this.sdNodes.ContainsKey(n.Id) == false)
                {
                    this.sdNodes.Add(n.Id, n);
                }
                else
                {
                    bNoError = false;
                }
            }

            return bNoError;
        }


        /// <summary>
        /// Nodes the exists.
        /// </summary>
        /// <param name="strNodeId">The string node identifier.</param>
        /// <returns></returns>
        public bool NodeExists(string strNodeId) => this.sdNodes.ContainsKey(strNodeId);


        /// <summary>
        /// Nodes the exists.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public bool NodeExists(Node n) => this.sdNodes.ContainsKey(n.Id);


        /// <summary>
        /// Gets the node.
        /// </summary>
        /// <param name="strNodeId">The string node identifier.</param>
        /// <returns></returns>
        public Node GetNode(string strNodeId) => this.sdNodes[strNodeId];


        /// <summary>
        /// Removes the node.
        /// </summary>
        /// <param name="n">The n.</param>
        public bool RemoveNode(Node n)
        {
            if (this.sdNodes.ContainsKey(n.Id))
            {
                this.sdNodes.Remove(n.Id);
                return true;
            }

            return false;
        }


        /// <summary>
        /// Removes the node.
        /// </summary>
        /// <param name="strNodeId">The string node identifier.</param>
        public bool RemoveNode(string strNodeId)
        {
            if (this.sdNodes.ContainsKey(strNodeId))
            {
                this.sdNodes.Remove(strNodeId);
                return true;
            }

            return false;
        }

        #endregion

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        #region Edge Operations

        /// <summary>
        /// Clears the edges.
        /// </summary>
        public void ClearEdges() =>
            // Hier werden nur die Verbindungen zwischen den Knoten gelöscht,
            // die Knoten selbst bleiben natürlich erhalten.
            this.sdEdges.Clear();


        /// <summary>
        /// Adds the edge.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        public bool AddEdge(Edge e)
        {
            if (this.sdEdges.ContainsKey(e.Id) == false)
            {
                this.sdEdges.Add(e.Id, e);
                return true;
            }

            return false;
        }


        /// <summary>
        /// Adds the edge.
        /// </summary>
        /// <param name="nSource">The n source.</param>
        /// <param name="nDestination">The n destination.</param>
        /// <param name="d">The d.</param>
        /// <returns></returns>
        public Edge AddEdge(Node nSource, Node nDestination, Direction d)
        {
            if (this.sdNodes.ContainsKey(nSource.Id) == false)
            {
                this.sdNodes.Add(nSource.Id, nSource);
            }

            if (this.sdNodes.ContainsKey(nDestination.Id) == false)
            {
                this.sdNodes.Add(nDestination.Id, nDestination);
            }

            Edge e = new() { Source = nSource, Destination = nDestination, Direction = d };

            this.sdEdges.Add(e.Id, e);

            return e;
        }


        /// <summary>
        /// Adds the edge.
        /// </summary>
        /// <param name="nSource">The n source.</param>
        /// <param name="nDestination">The n destination.</param>
        /// <returns></returns>
        public Edge AddEdge(Node nSource, Node nDestination) => AddEdge(nSource, nDestination, this.DefaultDirection ?? Direction.SourceToDestination);


        /// <summary>
        /// Adds the edge.
        /// </summary>
        /// <param name="strSourceId">The string source identifier.</param>
        /// <param name="strDestinationId">The string destination identifier.</param>
        /// <returns></returns>
        public Edge AddEdge(string strSourceId, string strDestinationId) => this.sdNodes.ContainsKey(strSourceId) && this.sdNodes.ContainsKey(strDestinationId)
                                                                                ? AddEdge(this.sdNodes[strSourceId], this.sdNodes[strDestinationId])
                                                                                : null;


        /// <summary>
        /// Removes the edge.
        /// </summary>
        /// <param name="e">The e.</param>
        public bool RemoveEdge(Edge e)
        {
            if (this.sdEdges.ContainsKey(e.Id))
            {
                this.sdEdges.Remove(e.Id);
                return true;
            }

            return false;
        }

        #endregion

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Adds the specified n.
        /// </summary>
        /// <param name="n">The n.</param>
        public void Add(Node n) => AddNode(n);


        /// <summary>
        /// Adds the specified e.
        /// </summary>
        /// <param name="e">The e.</param>
        public void Add(Edge e) => AddEdge(e);


        /// <summary>
        /// Removes the nodes without edge.
        /// </summary>
        public void RemoveNodesWithoutEdge()
        {
            List<string> lNodesToRemove = new();

            foreach (string strNodeId in this.sdNodes.Keys)
            {
                bool bFound = false;

                foreach (Edge e in this.sdEdges.Values)
                {
                    if (e.Source.Id.Equals(strNodeId))
                    {
                        bFound = true;
                        break;
                    }

                    if (e.Destination.Id.Equals(strNodeId))
                    {
                        bFound = true;
                        break;
                    }
                }

                if (bFound == false)
                {
                    lNodesToRemove.Add(strNodeId);
                }
            }

            lNodesToRemove.ForEach(id => this.sdNodes.Remove(id));
        }


        /// <summary>
        /// Gets the node edges.
        /// </summary>
        /// <param name="nNode">The n node.</param>
        /// <param name="dDirection">The d direction.</param>
        /// <returns></returns>
        public List<Edge> GetNodeEdges(Node nNode, Direction? dDirection)
        {
            List<Edge> lEdges = new();

            foreach (Edge e in this.sdEdges.Values)
            {
                Node x = null;
                Direction? dHelp = dDirection;

                if (e.Source.Id.Equals(nNode.Id))
                {
                    x = e.Source;
                }
                else
                {
                    if (e.Destination.Id.Equals(nNode.Id))
                    {
                        x = e.Destination;

                        //Direction auch umdrehen da jetzt andere Sicht
                        if (dHelp != null)
                        {
                            switch (dHelp.Value)
                            {
                                case Direction.SourceToDestination:
                                    dHelp = Direction.DestiantionToSource;
                                    break;

                                case Direction.DestiantionToSource:
                                    dHelp = Direction.SourceToDestination;
                                    break;
                            }
                        }
                    }
                }

                if (x != null)
                {
                    if (dHelp == null)
                    {
                        lEdges.Add(e);
                        continue;
                    }

                    if (e.Direction == dHelp)
                    {
                        lEdges.Add(e);
                    }
                }
            }

            return lEdges;
        }


        /// <summary>
        /// Gets the node edges count.
        /// </summary>
        /// <param name="nNode">The n node.</param>
        /// <param name="dDirection">The d direction.</param>
        /// <returns></returns>
        public int GetNodeEdgesCount(Node nNode, Direction? dDirection) => GetNodeEdges(nNode, dDirection).Count;


        /// <summary>
        /// Liefert alle doppelten Kanten gleichen Kantentypes mit gleichen Knoten zurück.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Edge> GetDoubleEdges() => throw new NotImplementedException();


        /// <summary>
        /// Liefert alle Kanten zurück zu denen es keinen Knoten mehr gibt.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Edge> GetEmptyEdges() => throw new NotImplementedException();
    }
}
