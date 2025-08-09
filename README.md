# Domain-Driven Design: A Portfolio Project
[![MIT License](https://img.shields.io/badge/License-MIT-blue.svg)](https://choosealicense.com/licenses/mit/) ![Static Badge](https://img.shields.io/badge/build-passing-green) 


This is a project I've decided to make in order to show-case the depth of domain-driven design and [how it tackles complexity in the heart of software](https://fabiofumarola.github.io/nosql/readingMaterial/Evans03.pdf).

I hope that this project can help someone getting started with Domain-Driven design, to sort of grasp ideas that they may have missed out on.

I've also been writing [a blog series about Domain-Driven design](https://linque.hashnode.dev/series/domain-driven-design) that's quite provocative but very informative. Also please understand that there many different ways of solving problems in code, and mine isn't necessarily what I think is the "best" or the "only" way, its rather *a way*, the way I chose to tackle this.


> **Note:** I have severely over-complicated the design in this project to try and show difficult concepts and capture the depth of domain-drivne design.
Much of this work can be simplified and not every project, in fact most (small-scale) projects do not warrant the use of Domain-Driven design, let alone clean-architecture.

## 🏦 The Domain

The overall business problem (space), *aka the domain*, that we will be focusing on is a business that **rents out cars to customers**. It may seem straight-forward at first, however, this can be a very complicated domain, depending on how deep we go. There are many invariants and state transitions that require cross-context communication.

#### The topics I try to tackle
- Strategic Design (Subdomains, BoundedContexts, ContextMapping)
- Tactical Design (AggregateRoots, Entities, ValueObjects)
- Event-Driven Architecture (Domain Events)
- CQRS
- ... and more

## 🛠️ Architecture
Domain-Driven Design is not an architectural pattern or a folder structure but rather a way of thinking that encourages modelling code based on the business.

There are many different ways of applying this in terms of code structure and there isn't a "best" way, but for the purpose of this project, I will be using [Clean Architecture](https://www.c-sharpcorner.com/article/clean-architecture-in-asp-net-core-web-api/), an evolution of the Onion architecture that encourages inward-pointing dependencies, adapted by [Robert C. Martin in the book "Clean Code"](https://github.com/Gatjuat-Wicteat-Riek/clean-code-book/blob/master/Clean%20Code%20(%20PDFDrive.com%20).pdf).

All of the different variations: clean architecture, onion, ports-and-adapters, hexagonal, etc. are a variation, different visualization, or cosmetic differences of two principles regarding Dependency Inversion as a foundational:

- Abstractions should not depend upon details; details should depend upon abstractions.
- Higher-level modules should not depend upon lower-level modules; both should depend upon abstractions.



**Folder structure:**
```
📁 src/
├── 🥜 Demo.SharedKernel/
│   └── ...
├── 🏦  Demo.Domain/
│   └── ...
├── 🔌 Demo.Application/
│   └── ...
├── 🛠️ Demo.Infrastructure/
│   └── ...
└── 🛜 Demo.WebApi/
    └── ...
```

<img 
    width="500" 
    alt="Clean Architecture Diagram" 
    title="The Onion Diagram of Clean Architecture"
    src="https://blog.ndepend.com/wp-content/uploads/Clean-Architecture-Diagram-Asp-Net.png" 
/>


## 🌿 Contributions
All contributions are welcome

## 📝 Authors
[@l1nque](https://github.com/L1nque/)

## 🧑‍💻 Related
Here are some related projects:

[Event-Sourcing: A Portfolio Project]() `(coming soon)`

[Vertical-Slice Architecture]() `(coming soon)`

[Microservices with .NET]() `(coming soon)`