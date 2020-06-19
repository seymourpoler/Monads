# Monads
[![Build Status](https://travis-ci.org/seymourpoler/Monads.svg?branch=master)](https://travis-ci.org/seymourpoler/Monads)

An implementation of monads in csharp, with JetBrains Rider as IDE ![Rider](jet.brains.rider.logo.png?raw=true){height="24px" width="24px"}  and Lubuntu 18.04 LTS as operating system

# Monad.Maybe
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
