# Pretzel.Quote
A quote tag for Pretzel

This is a plugin for the static site generation tool [Pretzel](https://github.com/Code52/pretzel).

### Usage

```
{% quote [author[, source]] %}
Quote string
{% endquote %}
```

The source is EVERYTHING after the comma.

**Warning** : Put the author within quotes if it contains a ','.

### Installation

Download the latest [release](https://github.com/k94ll13nn3/Pretzel.Quote/releases) and copy `Pretzel.Quote.dll` to the `_plugins` folder at the root of your site folder.