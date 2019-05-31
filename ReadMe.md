# ServiceBase
MicroService .Net Core Template using Clean Architecture and Domain Events.

## Structure
The structure is broken into three main projects.
* ServiceBase.Core - The Domain Model and Use Cases
* ServiceBase.Infrastructure - Persistent storage and third party access.
* ServiceBase.Api - The Controllers and Dtos.

The importance of this structure is that Core has no references to the other two projects 
making the core business logic easy to unit test.

