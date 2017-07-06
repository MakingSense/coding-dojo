## Table of contents
- [Regex, Paper, Scissors, Lizard, Spock](#Regex-Paper-Scissors-Lizard-Spock)
- [References](#references)

# Regex, Paper, Scissors, Lizard, Spock

For this challenge, you should write five regexes R, P, S, L and V such that they match each other in a cyclic Rock, Paper, Scissors, Lizard, Spock fashion. Here's a handy table:

| Regex | Matches | Doesn't match |
|-------|---------|---------------|
| R     | L,S     | V, P          |
| L     | V, P    | S, R          |
| V     | S, R    | P, L          |
| S     | P, L    | R, V          |
| P     | R, V    | L, S          |

Just to be clear, you should *not* match the string R, P, etc, but the other regexes. E.g. if your regex R is `^\w$` for example, then P and V have to match the string `^\w$`, whereas S and L shouldn't.

Match just means that at least one (possibly empty) substring of the input is matched. The match does not need to cover the entire input. For example \b (word boundary) matches `hello` (at the beginning and at the end), but it doesn't match `(^,^)`.

You may use any regex flavour, but please state the choice in your answer and, if possible, provide a link to an online tester for the chosen flavour. You may not use any regex features that let you invoke code in the flavour's host language (like the Perl flavour's `e` modifier).

Delimiters (like `/regex/`) are not included in the regex when given as input to another, and you cannot use modifiers that are outside of the regex. Some flavours still let you use modifiers with inline syntax like `(?s)`.

Your score is the sum of the lengths of the five regexes in bytes. Lower is better.

It turns out to be a lot simpler to find a working solution to this problem than it may seem at first.

Good luck!

### References

#### Regular expressions

[Dot Net Perls: Regex](https://www.dotnetperls.com/regex)

