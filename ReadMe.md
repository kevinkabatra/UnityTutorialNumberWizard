# UnityTutorialNumberWizard
Kata that involved me learning how to make a simple "game" using:
* Unity game engine
* Binary Search algorithm
* Mediator design pattern

## Background
In 2017 I purchased a Udemy course to learn how to create video games using Unity. Unfortunately, I did not do much with it at the time. Life tends to get in the way of researching something for the sake of researching it.

I did enjoy the course, though I did only complete two of the lessons, because it was very orientated towards a junior Unity and C# developer. Once I wanted to expand upon their content I ran into difficulty. Many of the systems developed within the tutorials were tightly coupled together, this made maintaining the software very difficult. I recall that at the time I wanted to add additional "levels" to their text-based game. The spaghetti code enabled me to attempt to bolt my newest design to the original work, but this resulted in a kludge that to this day still does not work correctly. Eventually we will rebuild it. Eventually.

Well all of these years later I am finally getting around to revisit this topic. With this newest attempt I want to bring my current understanding of software development and with using design patterns and some of the principles of SOLID I think that I can conquer this mountain once and for all.

## Number Wizard Design
In this project the "game", I write it this way because this seems that it would be super boring to play, attempts to guess a number that the user will pick. In its current implementation the user can pick any number between 0 and 1000, but this can be easily expanded upon. It determines the number by using the Binary Search algorithm to essentially brute force the number.

Since this game is based in Unity I must architect the `Number Wizard` so that it can run within the Unity game engine as well as be easy to maintain and expand later on.

### Mediator Design Pattern
This design pattern lets you reduce dependencies between the various components of an application by restricting the communication between them and only allowing it through the mediator.

The first stop for the application is the `Main.cs` file, this class acts as the `Mediator` between all of the various components of the game. If I need to update the input handling based on the current state of the game I should not include additional logic within the `InputHandler` class. Instead I should have:
* an enum that will contain all of the support game states
* a handler that will watch for a user's input
* and have the mediator determine what to do with the input based on the current game state, which is stored within the mediator.

### Dependency inversion principle
This principle focuses on decoupling the various software modules / components from one another. I follow this principle when setting up my `Guess Handler` which depends on a `search engine` and a `display`. 

#### Search Engine
The code for the `search engine` is almost entirely implemented using the abstract class `SearchEngine.cs` with only the actual algorithmic portion of the implementation being defined within `BinarySearchEngine`. 

Because of this design it would be rather simple to support additional search algorithms. All that would be required is to add additional implementation classes of the various search mechanisms, specifically the `FindGuess()` function. Then update the mediator for their support. Possibly we could prompt the user as to which search engine they would like to try their luck against.

Using this approach we could possibly support a:
* linear search, that could take quite awhile to resolve the number though
* random number generator, depending on the number this could be faster than a linear search
* utility that guesses the same guess over and over again, attempting to force the user into capitulation. Could there have been only 4 lights?

This shows the major benefit of this design principle, where it is extremely easy to support additional features without massive refactoring to the existing system.

#### Display Handler
Similarly, the `display` is actually defined with its interface that is stored in the business logic assemblies and is only implemented within the application logic. The reason for this is that the handler for the display requires access to the Unity assemblies and would violate the separation of our Application and Business Logic.

Following this approach also enables us to Mock our interface when testing the `Guess Handler` within the business logic assemblies. Doing so allows me to guarantee that the `Guess Handler` is performing as expected without worrying about the details of the `Display Handler` implementation or those pesky Unity assemblies.

### Binary Search Algorithm
Binary searching enables us to find a target value within a sorted array. In our program the array (A) is a list of numbers (n) from a minimum number (L) to a maximum number (R). To find our target (T) we will offer the user the middle position (m) of the array as a possible option. Assuming that current middle position does not equal our target, the user will then tell us which half, above our below the current middle position, we can eliminate. This process repeats until we find our target.

Equation: m = floor of (L+R) / 2

## References
1. Udemy class: https://www.udemy.com/course/unitycourse/.
1. Mediator Design Pattern further explained: https://refactoring.guru/design-patterns/mediator.
1. SOLID principles further explained: https://itnext.io/solid-principles-explanation-and-examples-715b975dcad4.
1. Binary Searching further explained: https://en.wikipedia.org/wiki/Binary_search_algorithm#Algorithm.
1. There are four lights: https://en.wikipedia.org/wiki/Chain_of_Command_(Star_Trek:_The_Next_Generation).