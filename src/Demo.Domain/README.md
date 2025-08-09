# The Domain Layer
You've reached the heart of the application. This is the core layer of our application where we implement the logic related to our business. It captures the business rules, policies, and concepts that define how our business operates, with no dependence on technical concerns such as databases, frameworks, or external APIs.

This is where we express the ubiquitous language of the business through strategic & tactical building blocks:
- Entities & AggregateRoots: Objects with identity & lifecycle, responsible for enforcing invariants.
- ValueObjects: Immutable representations of domain concepts defined by their attributes and not their identity.
- Domain Services: stateless operations that encapsulate domain logic that does not belong naturally to an Entity or VO
- Policies & Specifications: rules and constraints that guide decisions and enforce consistency.

## The Car Rental Business
Our overall domain, or rather the business we are operating in is the Car Rental Business (this can change in the future depending on business goals, and opportunities), but in reality, this business is made up of many "subdomains":
- Fleet Management: manages the fleet, maintanence, lifecycle, etc.
- Rental Contracting: creating and managing rentals
- Customer Relations: onboarding customers, loyalty and behavior
- Traffic Violations & Toll usage: tracking violations and by coordinating with government APIs






# Dependencies: Little to None

# How I like to think about different subdomains
As unique, independent, isolated pieces that should work on their own -- as if Im building a different app

# Domain Model != Persistance Moel
```csharp
public class RentalAggregate // Domain Layer
{
    RentalId Id;
    RentalCar Car;
    Driver Driver;
    MileagePolicy Mileage;
}

public class RentalPersistenceModel // Infrastructure
{
    public Guid Id;
    public Guid CarId;
    public Guid CustomerId;
    public float MileagePolicy_Allowance;
    public decimal MileagePolicy_ExcessFee;
}

```

# Can use Read Projections
To create custom read models
That are blazingly fast to query
Storage is the cheapest cost; Compute is expensive.


# Domain Model == Commands/Writes/Mutations

# Folder Structure

# The Specification Pattern

# Each module is designed in isolation
It should have no intrinsic knowledge that it is part of a "Car Rental Software."
A well-designed Lego block has a clear, standard purpose. A 2x4 red brick is just that. It has standard studs on top and tubes on the bottom. It doesn't know if it will be used to build a spaceship, a castle, or a car. Its generic, well-defined interface is its power.
A poorly-designed Lego block would be a "castle wall piece" that has a little "spaceship window" molded into it. It's now less useful. It's coupled to two different concepts.
Your FleetManagement context is a 2x4 red brick. Your RentalContracting is another block. The goal of your overall system architecture is to define how these standard blocks connect to build your specific "Car Rental" application.
Why This "Ignorance" is a Superpower
Designing your supporting subdomain to be generic and ignorant of the larger application provides enormous strategic benefits:
1. True Decoupling and Reduced Cognitive Load
The team working on FleetManagement has a crystal-clear, narrow mission: build the best system for tracking the physical state, location, and maintenance lifecycle of a vehicle fleet. They don't need to attend meetings about rental pricing strategies, customer loyalty tiers, or insurance add-ons. Their world is simpler, and they can build a better, more robust product because of that focus.
2. Extreme Reusability (Business Agility)
Imagine your car rental company decides to launch a new business venture:
A premium chauffeur service.
A "last-mile" delivery service using the fleet during off-peak hours.
If FleetManagement is generic, you can simply reuse it. You'd create a new ChauffeurService or DeliveryLogistics bounded context that plugs into the same FleetManagement block. If your FleetManagement model was polluted with "rental" concepts, it would be useless for these new ventures, forcing a costly rewrite or a messy fork.
3. The "Buy vs. Build" Option Becomes Viable
If you design FleetManagement around a generic, industry-standard set of concepts, you create a strategic option for the future. If a fantastic off-the-shelf Fleet Management SaaS product comes along, you can realistically replace your entire custom-built FleetManagement bounded context with that third-party product. You would only need to rewrite the Anti-Corruption Layer (ACL) that connects your Core domain to the new API. This is impossible if your supporting domain's model is tightly coupled to your Core domain's concepts.
4. Clearer Boundaries and Contracts
This approach forces you to be extremely deliberate about the "public API" of your FleetManagement context. You have to ask: "What are the absolute essential, generic commands and queries this context must support?"
FindAvailableVehicles(criteria)
AssignVehicleToParty(vehicleId, partyId)
ReportVehicleReturned(vehicleId, finalState)
ScheduleMaintenance(vehicleId)
This API is stable and clean. RentalContracting becomes just one of many potential "clients" of this API.
