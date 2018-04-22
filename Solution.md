## Solution ##
This problem is a perfect candidate for applying [composite pattern](https://en.wikipedia.org/wiki/Composite_pattern) .
Since we have some sort of hierarchical data, we need to traverse the
partial/full structure, and execute some action while doing so.

### Some common helper classes ###
First, we create couple of helper classes in order to better model the problem
domain. Among those, following are the most important ones.

1. **EmployeeInfo** interface containing common data like id, name, salary etc.
2. **ReviewSystem** interface containing the operations in the problem domain.
    For example, calculating salary, calculating group salary etc.
3. **Role** enum containing different role names and their corresponding
    impacts. Since impact are tightly coupled with the roles, we have
    leaned towards this type of class design.

Please have a look at the classes under the ```common``` package.

You can also have a look into the ```Main``` method to have see
  how these classes can be used in the final solution.


### Solving the problem using Composite pattern ###
First we observe the following hierarchy.

CTO -> Project manager -> Team lead -> Developer

So we need to have a tree like structure where Developer is the leaf node,
and others are branch nodes.

Once we make this observation the implementation is straight forward.
Please have a look at the classes under the ```composite``` package. Here
is a brief summary.

1. **Employee** interface represeting the hierarchical relationships. It
    also contains the problem domain functions like ```calculateGroupSalary``` etc.
2. **EmployeeImpl** this is the leaf node. It only thinks about itself.
3. **CompositeEmployee** class is the branch node. CTO, Project Manager,
    and Team Leads are this type of class. Have a look at how
      ```calculateGroupSalary``` method is implemented.
4. **CefaloReviewSystem** - this is where we used the composite pattern
      and solve our problem. Have a look at how it uses the ```EmployeeImpl```,
      ```CompositeEmployee``` classes.

Run the ```App.main``` function using the ```CefaloReviewSystem```
       implementation to see how everything fits together.


### Lets add some more functionality ###

Let's say we now have two more functionality that we need to add in the system.

1. Print the hierarchy starting from a specific node, it can be any node
2. Instead of complicated increment, what if everyone's salary is increase by
    a flat percentage.

Have a look at how both of this is implemented in the ```CompositeEmployee```
    class.

Test these two method in the main function and we are done.

Not quite!

If our goal is to learn the composite pattern and apply it to solve a
problem then we are done. But we have something better in our mind. Bear with me!

### Identifying common code ###

Let's look at the following three functions very closely.

```csharp
public double calculateGroupSalary() {
    double sum = calculateSalary();
    foreach (Employee employee in employees) {
        sum += employee.calculateGroupSalary();
    }
    return sum;
}

public double flatRaise(double percentage) {
    double sum = super.flatRaise(percentage);
    foreach(Employee employee in employees) {
        sum += employee.flatRaise(percentage);
    }
    return sum;
}

public String print() {
    String result = base.print();
    foreach (Employee employee in employees) {
        result = result + "\n" + employee.print();
    }
    return result;
}
```


Most of the time we think this type of functions are fine, and we don't
try to make them more generic/abstract. However, ***they are remarkably
similar***. We are doing the following things in those functions.
1. Get some initial value
2. Iterate the children, get some value from them, perform some operation
3. Return the final result

Can we abstract the above pattern in some way?

### Higher Order Functions to the rescue ###
***(Three cheers for Functional Programming!)***

[Higher order functions](https://en.wikipedia.org/wiki/Higher-order_function)
are functions that take functions as parameter, or return a function as result, or both.
 In our case HOF is a perfect candidate to solve the above mentioned
 steps. Let' take a look.

```csharp
private T fold<T>(
            T initialValue,
            Func<Employee, T> iteration,
            Func<T, T, T> combiner)
        {
            T result = initialValue;
            foreach (Employee emp in employees)
            {
                T val = iteration(emp);
                result = combiner(result, val);
            }
            return result;
        }
```

This function takes three parameters, and two of them are functions.
1. An initial ***value***
2. A ***function*** which takes an Employee as a parameter and gives us a value.
    This value will be used while we iterate the children.
3. A ***combiner function*** which takes two values of type T and returns a new T.
    For example it can be a **sum** function taking two integers and producing
    their sum as a result. Or a appender function in case of String values.

Let's now look into how we solve the problem using this ```fold``` function.

```csharp
public double calculateGroupSalary() {
    return fold(calculateSalary(), emp => emp.calculateGroupSalary(), (a, b) => a + b);
}

public double flatRaise(double percentage) {
    return fold(super.flatRaise(percentage), e => e.flatRaise(percentage), (a, b) => a + b);
}

public String print() {
    return fold(super.print(), emp => emp.print(), (s1, s2) => s1 + "\n" + s2);
}
```

That is some beautiful code there!

Wait, can we do better? No, really? Is it the best we can do?

Isn't hierarchical structure a common thing? Can we abstract it out somehow?

### Generics meets HOF ###
With the combined power of C# generics and lambda, we've now created the
 ```CompositeTree``` class. In addition to the node/child creation functions,
 it has the following two functions.

```csharp
   void forEach(T node, Action<T> action);

  U fold<U>(T node, U initValue, Func<T, U> extractor, Func<U, U, U> combiner);
 ```

It should be very familiar to you at this point. Have a look into the
```GenericReviewSystem``` to see how this ```CompositeTree``` can be used.

```forEach``` is used when we traverse the hierarchy, and are only interested to perform some actions.
```fold``` is used when we traverse the hierarchy, and want to perform some computation, and return the result.

Finally we observe the following things.
1. The ```CompositeTree``` is a flexible, and powerful abstraction. It can work with any type
 of hierarchical data, not only in our specified problem (e.g. employee hierarchy).
2. With the help of Generics and Functional Programming we've almost made a re-usable
 library abstracting the composite pattern. This would be very hard to do using
 traditional OOP.

***We encourage you to study Functional Programming concepts. It will help you identify
   more abstractions in your code.***