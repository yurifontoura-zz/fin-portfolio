# fin-portfolio
Question 1. Categorizing Financial Instruments in a Portfolio

## Input Example for Web Api

[
  {"MarketValue": 800000, "Type": "Stock"}, 
  {"MarketValue": 1500000, "Type": "Bond"}, 
  {"MarketValue": 6000000, "Type": "Derivative"}, 
  {"MarketValue": 300000, "Type": "Stock"} 
]

# Project architecture

## CrossDomain
This layer is for carrying out the pluggable libs and solve dependencies, in intention of decouple the dependency of the project. \n
Making easier to interchange between implementations without making too much code changes.\n
For example, the web api layer, does not has to know the repository layer that implements the domain's interface, or even what application implements the IFinInstrumentApp.\n
Once we pull off the references, newer developers can not unintetionally make the mistake of using an Domain entity inside the front-end facade.

## Application and it's interface
The Application.Interface layer is for hold the facade method signatures and the DTO's for input and output in intention of not expose the core domain entities.\n
The Application layer, also usually called as Services, is responsible for determine the flow of the rules and data gathering, but not hold an business logic itself. \n
In a nutshell, this layer knows **WHEN** the things shall happen.

## Domain
This one shall hold the pure core business logic, this layer know **HOW** to make the thing. And also, has the entities.

## Repository
This Repository.MS (MS is for Microsoft, in intention of separate SqlServer layer for another), should carry out the query logic, which can also be decoupled and stored in the Domain layer.\n
This layer basic knows **FROM WHERE** the data comes.
