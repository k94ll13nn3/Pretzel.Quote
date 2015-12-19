# Pretzel.Quote

[![Build status](https://ci.appveyor.com/api/projects/status/3a6hq368ieu3oijy?svg=true)](https://ci.appveyor.com/project/k94ll13nn3/pretzel-quote)
[![Release](https://img.shields.io/github/release/k94ll13nn3/Pretzel.Quote.svg)](https://github.com/k94ll13nn3/Pretzel.Quote/releases/latest)

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

Download the [latest release](https://github.com/k94ll13nn3/Pretzel.Quote/releases/latest) and copy `Pretzel.Quote.dll` to the `_plugins` folder at the root of your site folder.