# UTILIZZO MD
il linguaggio di markup(in inglese, markup )


# Titolo principale
## Sottotitolo 1
### Titolo paragrafo
#### Sottotitolo paragrafo
---

> esempio di quote (citazione)

esempio di __grassetto__ o **bold**

esempio di _italic_

# esempio di elenco puntato
---
- primo
    - sottoelenco
- terzo
- quarto
- quinto

# esempio di elenco numerato
---
1. primo
2. secondo
3. terzo
    i. quarto
    ii. quinto
        a. sesto
        b. settimo
        c. ottavo
            a. nono
            b. decimo
            c. undicesimo

## esempio di check
- [x] sdd
- [ ] primo
- [ ] secondo
- [x] terzo

# Esempio di codice
```
git status
git add
git commit
```

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}

/*
note per i collaboratori
*/
```

**esempio di link relativo**

[link a pagina 2 link](02_link.md)

[link a pagina web](https://www.google.com)

[link a pagina 3 dentro la sub](/Esercitazioni/02_md/subfolder/03_link.md)

[link ad una section del documento](#esempio-di-elenco-puntato)

<!-- Commento che non compare nel render markdown> -->

| Syntax | Description |
| ----------- | ----------- |
| Header | Title |
| Paragraph | ![esempio di SVG di svg repo]|



<font color="red">Testo scritto in rosso!</font>

### Sezioni

<details>

<summary>Tips for collapsed sectionist</summary>

### You can add a header

You can add text within a collapsed section.

You can add an image or a code block, too.

```ruby
    puts "Hello World"
```

</details>
Here is a simple flow chart:

`esempio di mark con i backtick`

<mark>gedfgdfg</mark>

<mark style=" background:red">gedfgdfg</mark>

## GRAFICI MERMAID

https://mermaid.js.org/
https://jojozhuang.github.io/tutorial/mermaid-cheat-sheet/

## FLOWCHART BASIC

```mermaid
graph TD;
    A-->B;
    A-->C;
    B-->D;
    C-->D;
```
## 