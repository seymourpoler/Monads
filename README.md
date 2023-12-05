# Monads
[![Build Status](https://travis-ci.org/seymourpoler/Monads.svg?branch=master)](https://travis-ci.org/seymourpoler/Monads)

An implementation of monads in csharp, in Lubuntu 18.04 LTS as operating system and with JetBrains Rider as IDE  <img src="jet.brains.rider.logo.png" width="30px" height="30px">

# Monad.Maybe
Very simple monad Maybe library written in c-sharp.

Create Monad from:
```c#
	Maybe<string>.Of("Hello")
```

Return value or another element
```c#
	var result = Maybe<string>.Of("Hello")
			    .match(() => "bye", null);
```

Simple string tokenizer
```c#
	var result = Maybe<string>.Of("Hello")
			    .Bind<List<string>> (y => y.Split(' ').ToList<string>())
			    .Match(x => x, _ => new List<string>());
```
