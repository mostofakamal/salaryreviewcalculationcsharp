using System.Collections.Generic;
using System.Linq;

namespace Salary_Review_Calculation.Generic
{
    public class TreeNode<T> : Node<T>
    {
        private T data;
        private List<Node<T>> children = new List<Node<T>>();

        public TreeNode(T data)
        {
            this.data = data;
        }

        public T getData()
        {
            return this.data;
        }

        public List<Node<T>> getChildren()
        {
            return this.children;
        }

        public void addChild(Node<T> child)
        {
            children.Add(child);
        }

        public void removeChild(Node<T> child)
        {
            children.Remove(child);
        }

        public bool isLeaf()
        {
            return !children.Any();
        }
    }
}