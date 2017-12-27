## Table of contents
- [Sieve of Eratosthenes](#sieve-of-eratosthenes)
- [References](#references)

# Sieve of Eratosthenes

In mathematics, the sieve of Eratosthenes, one of a number of prime number sieves, is a simple, ancient algorithm for finding all prime numbers up to any given limit. It does so by iteratively marking as composite (i.e., not prime) the multiples of each prime, starting with the multiples of 2.

To find all the prime numbers less than or equal to a given integer n by Eratosthenes' method:
- Create a list of consecutive integers from 2 through n: (2, 3, 4, ..., n).
- Initially, let p equal 2, the smallest prime number.
- Enumerate the multiples of p by counting to n from 2p in increments of p, and mark them in the list (these will be 2p, 3p, 4p, ...; the p itself should not be marked).
- Find the first number greater than p in the list that is not marked. If there was no such number, stop. Otherwise, let p now equal this new number (which is the next prime), and repeat from step 3.
- When the algorithm terminates, the numbers remaining not marked in the list are all the primes below n.

Your task is to implement it on your favorite programming language.

Good luck!

### References

#### Prime Numbers - Sieve of Eratosthenes

[![Prime Numbers - Sieve of Eratosthenes](http://img.youtube.com/vi/V08g_lkKj6Q/0.jpg)](http://www.youtube.com/watch?v=V08g_lkKj6Q)

[Wikipedia: Sieve of Eratosthenes](https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes)
