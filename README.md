## Problem Summary ##
Let's develop a *Salary Review Calculator* for Cefalo Management where Cefalo can calculate review for a single team or for all the teams currently are in operation. 
To keep the problem as simple as possible let's consider the following 4 common responsibilities in Cefalo-

1. **CTO**
2. **Project Manager**
3. **Team Lead**
4. **Developer**

To mention- 
1. Every team must have 1 or more developers.
2. Every project must have 1 or more teams

For calculating review we can consider the following 2 review calculation components-

1. *Score* - For every developer there will be a performance score considering the following performance indicators-
    1. **Problem Solving**
    2. **Years Of Experience**
    3. **Leadership Capability**
    4. **Communication Skill**
    5. **Decipline**

    In Cefalo these kind of evaluation are done using a 360-degree review within the team and/or from the teams respective Customer feedback. 
    Either way Score value will be max 10 for each performance indicator.

2. *Impact* - This component indicates how Cefalo values the performance indicators(listed above) that are collected for each developer as performance Scores. 

So as an example for a Developer if someone's *Problem Solving* score is 8(out of 10) then Cefalo may value the full of it(i.e 100%). 
Then if the *Communication* Score is 7(out of 10) Cefalo will consider the 80% of it. 
Similary the rest of performance will be impacted as defined by Cefalo. 
And we also have to bear in mind that the different Impact points will be applicable for defferent roles. 
To clear this up lets consider *Leadership* indicator- for a developer Cefalo may consider an Impact of 50% of his gained Score on *Leadership*. But for a Teamleader they may consider 80% of what a TeamLeader got on *Leadership* Score.

Taking the above two components into account, for a technical person the salary increment will be calculated using the following simple algorithm-

_RevisedSalary = CurrentSalary + CurrentSalary * ((PS_S/10  PS_I/100) + (C_S/10  C_I/100) + (D_S/10  D_I/100) + (E_S/10  E_I/100) + (L_S/10  L_I/100))_

From the above expression -
* PS_S - Problem Solving Score  
* PS_I -  Problem Solving Impact
* C_S -  Communication Score    
* C_I - Communication Impact
* D_S -  Decipline Score        
* D_I - Decipline Impact
* E_S -  Experience Score
* E_I - Experience Impact
* L_S -  Leadership Score
* L_I - Leadership Impact

The code snippets for the above algorithm could be something like-
```java
public double calculate() {

        double result = this.salary;
        result += countBaseScore();
        result += countDisciplineScore();
        result += countProblemSolvingScore();
        result += countLeadershipScore();
        result += countCommunicationScore();
        result += countExperienceScore();

        return result;
    }

    private double countBaseScore() {
        return this.salary * 0.05;
    }

    private double countDisciplineScore() {
        return salary * (score.getDecipline() / 10) * impact.getDisciplineImpact();
    }

    private double countProblemSolvingScore() {
        return salary * (score.getProblemSolving() / 10) * impact.getProblemSolvingImpact();
    }

    private double countLeadershipScore() {
        return salary * (score.getLeaderShip() / 10) * impact.getLeadershipImpact();
    }

    private double countCommunicationScore() {
        return salary * (score.getCommunication() / 10) * impact.getCommunicationImpact();
    }

    private double countExperienceScore() {
        return salary * (score.getYearsOfExperience() / 10) * impact.getExperienceImpact();
    }
```
You will find the full implementation of this algorithm in _com.cefalo.school.calculator.ReviewCalculator_ class.
And the supporting classes(Impact and Score) of the review calculation components are also available in _com.cefalo.school.calculator_ package.


### Prerequisite ###
In this course we will be doing our labworks using java or C#. So please make sure you have the following runtime and tools installed on your system-
* Java/.NET Framework
* Maven if you are using Java
* Pick your gavourite IDE(IDEA/VS Code/MS Visual Studio) with which you feel comfortable
* Make sure everything is ready to write, compile, run/debug code on your system

### Tasks ###

* Calculate review for a team or project or all the running projects of Cefalo.
* Make sure your desiged system can remove developer(s), team(s) or project(s) at any time
* And also it can welcome new developers(s), team(s) and project(s) at any time

### Expectations ###
* Calculate salary review uniformly
* Try to make the implementation as much re-usable as possible