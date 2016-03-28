namespace Hierarchy.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

    using Wintellect.PowerCollections;
    using System.Linq;
    public class Hierarchy<T> : IHierarchy<T>
    {
        private Node<T> root;
        private Dictionary<T, Node<T>> elements;

        public Hierarchy(T element)
        {
            this.root = new Node<T>(element);
            this.elements = new Dictionary<T, Node<T>>();
            this.elements.Add(element, this.root);
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Add(T element, T child)
        {
            Node<T> parent;
            if (!this.elements.TryGetValue(element, out parent))
            {
                throw new ArgumentException();
            }

            if (this.elements.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            var childNode = new Node<T>(child, parent);
            parent.Children.Add(childNode);
            this.elements.Add(child, childNode);
        }

        public void Remove(T element)
        {
            Node<T> node;
            if (!this.elements.TryGetValue(element, out node))
            {
                throw new ArgumentException();
            }

            if (node.Parent == null)
            {
                throw new InvalidOperationException();
            }

            var children = node.Children;
            var parent = node.Parent;
            parent.Children.AddRange(children);
            foreach (var child in children)
            {
                child.Parent = parent;
            }

            parent.Children.Remove(node);
            this.elements.Remove(node.Value);
        }

        public IEnumerable<T> GetChildren(T item)
        {
            if (!this.elements.ContainsKey(item))
            {
                throw new ArgumentException();
            }

            return this.elements[item].Children.Select(v => v.Value);
        }

        public T GetParent(T item)
        {
            if (!this.elements.ContainsKey(item))
            {
                throw new ArgumentException();
            }

            var parent = this.elements[item].Parent;

            if (parent == null)
            {
                return default(T);
            }

            return parent.Value;
        }

        public bool Contains(T value)
        {
            return this.elements.ContainsKey(value);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            var commonElements = new List<T>();

            foreach (T element in this.elements.Keys)
            {
                if (other.Contains(element))
                {
                    commonElements.Add(element);
                }
            }

            return commonElements;
        } 

        public IEnumerator<T> GetEnumerator()
        {
            if (this.Count == 0)
            {
                yield break;
            }

            var queue = new Queue<Node<T>>();
            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {
                var currentElement = queue.Dequeue();
                yield return currentElement.Value;

                foreach (var child in currentElement.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}