using System;
using System.Collections.Generic;

namespace Salary_Review_Calculation.Generic
{
    using Salary_Review_Calculation.Common;
    public class CompositeTree<T> : Tree<T> where T : Identity
    {
        private Dictionary<int, Node<T>> storage = new Dictionary<int, Node<T>>();


        public T createNode(T node)
        {
            TreeNode<T> tTreeNode = new TreeNode<T>(node);
            storage.Add(node.getId(), tTreeNode);
            return node;
        }


        public void forEach(T node, Action<T> action)
        {
            if (!storage.ContainsKey(node.getId())) return;

            Node<T> treeNode = storage[node.getId()];
            var data = treeNode.getData();

            action(data);

            foreach (Node<T> tNode in treeNode.getChildren())
            {
                forEach(tNode.getData(), action);
            }
        }


        public U fold<U>(T node, U initValue, Func<T, U> extractor, Func<U, U, U> combiner)
        {
            if (!storage.ContainsKey(node.getId())) throw new InvalidOperationException("Invalid tree state.");

            Node<T> tNode = storage[node.getId()];
            U currentValue = extractor(tNode.getData());

            U childResults = initValue;
            if (!tNode.isLeaf())
            {
                foreach (Node<T> childNode in tNode.getChildren())
                {
                    U intermediateResult = fold(childNode.getData(), initValue, extractor, combiner);
                    childResults = combiner(childResults, intermediateResult);
                }
            }

            return combiner(childResults, currentValue);
        }


        public Tree<B> map<B>(Func<T, B> transform)
        {
            //todo implement
            throw new NotImplementedException("TODO");
        }


        public void makeChild(T parent, T child)
        {
            if (storage.ContainsKey(parent.getId()) && storage.ContainsKey(child.getId()))
            {
                Node<T> parentNode = storage[parent.getId()];
                Node<T> childNode = storage[child.getId()];
                parentNode.addChild(childNode);
            }
        }


        public void removeChild(T parent, T child)
        {
            if (storage.ContainsKey(parent.getId()) && storage.ContainsKey(child.getId()))
            {
                Node<T> parentNode = storage[parent.getId()];
                Node<T> childNode = storage[child.getId()];
                parentNode.removeChild(childNode);
            }
        }
    }
}
