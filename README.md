# Pretzel.Quote
A quote tag for Pretzel

This is a plugin for the static site generation tool [Pretzel](https://github.com/Code52/pretzel).

### Usage

```
{% quote [author[, source]] %}
Quote string
{% endquote %}
```

For this first version, links are not supported as source.

### Installation

Compile the solution `Pretzel.Quote.sln` and copy `Pretzel.Quote.dll` to the `_plugins` folder at the root of your site folder (VS2015 needed).