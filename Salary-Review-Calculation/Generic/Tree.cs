using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_Review_Calculation.Generic
{
    public interface Tree<T>
    {
        T createNode(T node);

        void makeChild(T parent, T child);

        void removeChild(T parent, T child);

        void forEach(T node, Action<T> action);

        U fold<U>(T node, U initValue, Func<T, U> extractor, Func<U, U, U> combiner);

        Tree<B> map<B>(Func<T, B> transform);
    }
}
