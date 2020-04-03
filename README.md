# Monads
An implementation of monads in csharp, with JetBrains Rider as IDE and Lubuntu as operating system

# Monad.Mabe
Very simple monad Maybe library written in c-sharp.

Create Monad from:
```c#
	Maybe<string>.Of("Hello")
```

Return value or another element
```c#
	var result = Maybe<string>.Of("Hello")
			    .ValueOr(() => "bye");
```

Simple string tokenizer
```c#
	var result = Maybe<string>.Of("Hello")
			    .Bind<List<string>> (y => y.Split(' ').ToList<string>())
			    .ValueOr(new List<string>());
```
