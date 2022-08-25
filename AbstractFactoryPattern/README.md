# Abstract Factory Pattern

## O que é? What is it?

O design pattern "Abstract Factory" tem por objetivo permitir a criação de famílias
de objetos relacionados sem a especificar suas classes concretas.

Ao longo do código, talvez seja necessário realizar várias verificações para
descobrir qual classe de uma família deverá ser instanciada. Isso pode gerar problemas,
uma vez que será necessário lidar com as classes concretas diretamente, além de,
caso haja alguma mudança no código, poderemos gerar objetos de famílias diferentes,
que não são compatíveis entre si.

The objective of the "Abstract Factory" design pattern is to allow families of
related objects to be created without specifying their concrete classes.

Along the code, it may be necessary to perform checks to figure out which class
we should instanciate. This can cause a few problems, since we need to deal with
the concrete classes directly, besides, if there is a code change, we can generate
objects from different families, which are not compatible between themselves.

## Solução Ingênua - Naive Solution

A solução mais simples para o problema da criação dos objetos de uma família seria
verificar a condição(ões) que definem a família e, a partir disso, realizar a
instanciação dos objetos.

The simplest solution to the creation of a family of objects would be to check
the condition(s) that define the family and, after this, perform the objects
instantiation.

```csharp
// First code location

if (IsWindows(selectedOS))
{
    var button = new WinButton();
}
else
{
    var button = new MacButton();
}

// Second code location

if (IsWindows(selectedOS))
{
    var checkbox = new WinCheckbox();
}
else
{
    var checkbox = new MacCheckbox();
}
```

Como dito, com esse tipo de solução, nosso código depende das classes concretas
de cada objeto da família. Ainda, como a lógica de criação pode estar espalhada,
corremos o risco de realizar uma verificação errada, gerando objetos incompatíveis.
Por fim, caso haja alguma alteração na forma de construção dos objetos, precisaremos
percorrer todo código para ajustar cada um dos "new SomeClass()" espalhados.

As said before, with this type of solution, our code is dependent on the concrete
classes of each family of objects. Even more, since the creation logic might be
scattered, there's a risk we might perform a wrong verification, which would lead
to incompatible objects. Finally, if there is any modification on the objects
constructors, we would have to search all the "new SomeClass()" occurrences and
adjust them.

## Solução 'Abstract Factory' - 'Abstract Factory' Solution

Com as 'Abstract Factories', precisamos definir interfaces para cada tipo da família
\- e.g. IButton, ICheckbox, etc \-, além de definir uma interface para cada fábrica,
que terá uma lista de métodos de criação com retorno abstratos (interfaces dos tipos
da família).

With 'Abstract Factories', we need to define interfaces for each family's type
\- e.g. IButton, ICheckbox, etc \-, in addition to an interface for each factory,
which will have a list of creation methods with abstract returns (family's types
interfaces).

```csharp
public interface IButton
{
    // ...
}

public interface ICheckbox
{
    // ...
}

public interface IGuiFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}
```

Assim, podemos definir as implementações específicas para cada família de objetos,
além de uma implementação de factory específica, dependendo apenas das abstrações
(interfaces).

By doing this, we can define specific implementations for each object's family,
in addition to a specific factory implementation, which depends only on the
abstractions.

```csharp
public class WinButton : IButton
{
// ...
}

public class WinCheckbox : ICheckbox
{
// ...
}

public class WinFactory : IGuiFactory
{
public IButton CreateButton() => new WinButton();

public ICheckbox CreateCheckbox() => new WinCheckbox();
}
```

Dessa maneira, centralizamos cada lógica de criação das várias famílias em um
lugar específico, além de garantir que os objetos criados sejam compatíveis entre
si.

This way, we centralize each creation's logic of all the families in a specific
location, while also guaranteeing that the created objects are compatible amongst
themselves.

## Relação com outros Patterns - Relation with other Patterns

O pattern se relaciona com: Factory Method, Prototype, Builder, Facade e Bridge.
Também pode ser implementado como um Singleton.

O pattern 'Builder' foca na construção de objetos complexos passo a passo. Ao
combinar com uma 'Abstract Factory', podemos criar objetos complexos, que são
retornados.

'Abstract Factories' normalmente são baseados no 'Factory Method', mas o 'Prototype'
também pode ser utilizado para compor os métodos dessas classes.

O pattern também pode servir como uma alternativa ao 'Facade' quando se quer esconder,
do cliente, apenas a criação dos objetos.

Também pode ser usado com 'Bridge'. Essa combinação pode ser útil quando as abstrações
do 'Bridge' só podem funcionar com implementações específicas.

---

This pattern is related with: Factory Method, Prototype, Builder, Facada and Bridge.
It can also be implemented as a Singleton.

The 'Builder' pattern focuses on complex object's construction step by step. When
we combine it with a 'Abstract Factory', we can create complex objects, which are
returned.

'Abstract Factories' are usually based on 'Factory Methods', but the 'Prototype'
can also be used to compose these classes' methods.

The pattern can also be used as an alternative to 'Facade' when you want to hide,
from the client, only the objects' creation.

It can also be combined with 'Bridge'. This can be an useful combination when the
'Bridge's abstractions can only work with specific implementations.
