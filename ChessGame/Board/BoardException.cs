namespace Board
{
    public class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        {
        }
    }
}

/*
 
 This code defines a custom exception class called BoardException in the Board namespace. 
The BoardException class extends the built-in Exception class, which allows it to inherit 
all of the methods and properties of the base class.

The BoardException class has a single constructor that takes a string parameter message, 
which is passed to the base Exception class constructor using the base keyword.
This constructor allows the caller to specify a custom error message that will be 
associated with the exception object.

By creating a custom exception class, you can provide more specific error messages and
handle errors in a more granular way in your code. For example, in a chess game, you might 
throw a BoardException when an invalid move is attempted, with the error message indicating 
the specific reason for the error (e.g., "Invalid move: Knight cannot jump over pieces"). 
Then you could catch this exception in your code and take appropriate action, 
such as prompting the user to try a different move.
 
The benefit of defining a custom exception class like BoardException is that it allows you to 
handle specific types of errors in a more structured and granular way.




By creating a specific exception class, you can provide more information about the nature of 
the error, which can be useful in debugging and troubleshooting the issue. For example, in a chess game, 
you might use BoardException to indicate errors related to the game board,
such as an invalid move or an attempt to move a piece to an occupied square. 
This would allow you to distinguish these errors from other types of exceptions
that might occur in your code, such as network or database errors.

Additionally, by defining your own exception classes, you can provide more meaningful error messages to
users of your application. Rather than displaying a generic error message like "An error has occurred", 
you can display a message that provides more specific information about the error, such as
"Invalid move: Knight cannot jump over pieces".

Finally, by throwing custom exceptions in your code, 
you can also create a more structured error-handling mechanism.
This allows you to catch specific types of exceptions and handle them appropriately,
rather than catching all exceptions indiscriminately. This can make your code more robust and easier to maintain.
 
 */