[![Build status](https://ci.appveyor.com/api/projects/status/qlp7fuamo009nwsj/branch/master?svg=true)](https://ci.appveyor.com/project/flavio1110/checkout-kata/branch/master) [![Build Status](https://travis-ci.org/flavio1110/checkout-kata.svg?branch=master)](https://travis-ci.org/flavio1110/checkout-kata) [![Quality check](https://sonarcloud.io/api/project_badges/measure?project=flavio1110_checkout-kata&metric=alert_status&branch=master)](https://sonarcloud.io/dashboard?id=flavio1110_checkout-kata)



# Checkout Kata problem and Classical x Mockist approaches

## Problem
An e-commerce store has a list of products in its database, each product might have a special promotion. Today there are two active promotions:

- Get 2 and Pay 1: the customer get the second product free;
- Get 3 items for 10$: Regardless of the unit price, if the customer get 3 items, he or she will pay only 10$.

In the checkout, the customer should inform the quantity of each selected product and then it should see the total per product and the order total.

E.g.

|Product|Qty|Unit Price|Promotion|Price|
|-------|---|----------|---------|-----|
|T-shirt|2| $4|Get2Pay1|$4|
|Hat|4|$4|3ItemsPay10|$10|
|Glass|3|$3.4|3ItemsPay10|$10|
|Glober|3|$2||$6|

Total:$30

## Status

### Classic
I have completed the third iteration  of refactoring and now I moved more logic from my impure CheckoutService method to a deterministic place in Checkout class. On top of this clear separation I have more behavior in my class and the Checkout class is owns the creation of CheckoutItems. Looks better now. :)

### Mockist
I finished the first iteration of implementation using the mockist approach. The fact is my classes are more decoupled from its depedencies, however as pointed by others authors, it leads your tests to be more coupled in the implementation. Hence the refactoring becomes more complicated since I'll probably need to change my tests after the refactor my core code. I'll see it in practice in the next iterations using this approach.

## Motivation

After I watch the presentation of Mark Seeman about [Functional Architecture](https://vimeo.com/180287057), I was shocked with the correlation between pure and impure functions and their impact in the system design and of course in its quality. I highly recommend you to invest one hour of your time to watch it.

One of the most important points (IMO) mentioned by Seeman is related to the way we are building and testing our "decoupled OO systems"  might cause Test-Induced damage (43m51s).

Then after reading some posts about testability and TDD, I decided use this simple problem in order to try simulate the Classical and Mockist approach for development driven by tests. The goal is try to figure out which one is more suitable for this kind of problem and how a mindset could impact in the system design.

## Source
- [Functional Architecture - Mark Seeman](https://vimeo.com/180287057)

- [Classical vs Mockist testing - Jonathan Rasmusson](https://agilewarrior.wordpress.com/2015/04/18/classical-vs-mockist-testing/)

- [Mocks Aren't Stubs - Martin Fowler](https://martinfowler.com/articles/mocksArentStubs.html)

- [Mockists Are Dead. Long Live Classicists -  Fabio Pereira](https://www.thoughtworks.com/insights/blog/mockists-are-dead-long-live-classicists)
