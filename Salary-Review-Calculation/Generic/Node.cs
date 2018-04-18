using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_Review_Calculation.Generic
{
    /// <summary>
    /// The ode interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface Node<T>
    {
        T getData();

        List<Node<T>> getChildren();

        void addChild(Node<T> child);

        void removeChild(Node<T> child);

        bool isLeaf();
    }
}
