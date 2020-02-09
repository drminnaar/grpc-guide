![Alt Text](https://dev-to-uploads.s3.amazonaws.com/i/bj1lzxrson4glpqoxtj7.png)

# gRPC Guide

## tl;dr

In this guide, I aim to provide the salient points concerning _gRPC_ and _Protocol Buffers_. If you know what _gRPC_ and _Protocol Buffers_ are, then this guide is not for you. This is a guide for the beginner or the mildly interested.

_gRPC_ is a framework for building API's and is an alternative to JSON and XML based services. gRPC has the following attributes:

- a free and open-source framework that was originally developed by Google but is now part of the Cloud Native Computing Foundation (CNCF)
- a cross-platform and language agnostic
- built on HTTP/2 and supports unary and streaming communication

_Protocol Buffers_ serialize structured data and are used by default by gRPC. Protocol Buffers have the following attributes:

- are language agnostic
- help structure information for serialization
- facilitates code generation
- results in small payloads and efficient serialization due to data being binary

Most of the concepts in this guide are language agnostic. However, for now, I only provide examples in C# using .NET Core 3.1. The examples have been tested on both Linux and Windows. All examples have been created using [Visual Studio Code] with the [C# for Visual Studio Code] extension. Find the examples here,

- [Messenger]
- [Calculator]

---

## Introduction

In a nutshell, gRPC can be summed up as follows,

> A high performance, open-source universal RPC framework
>
> -- _https://grpc.io_

Before delving into gRPC, I'd like to take a step back and understand the problem that gRPC solves. For that I need to discuss the theory of communication fundamentals. Although this is a technical article, I won't be discussing communication theory as applied to computing systems. Instead, I will discuss an example of 2 people speaking.

Let’s imagine 2 people having a discussion in the same room. Both people speak the same language and the communication medium is essentially the same shared space in which the 2 people are speaking. For now we will keep it simple and make the assumption that the communication is unidirectional (communication happens in one way at a time).

- The _Sender_ sends a message (request) to the _Receiver_ and waits for a response
- The _Receiver_ receives the message (request) and returns a response as another message

Because the 2 people are in the same room speaking the same language, the communication is very simple. There is no need for anything special to enable successful communication. For clarity, the following attributes can be observed for this type of communication.

- Same language
- Same space (non-distributed)
- Same medium

The following diagram further illustrates how the communication occurs for this scenario.

![grpc-comms-1](https://user-images.githubusercontent.com/33935506/73964490-28a41800-4977-11ea-877b-26542bb2f27f.png)

Now imagine that we have 2 people that are in separate rooms, in different countries, and speak different languages. The following attributes contrast the difference to the example used above:

- Different language
- Different space (distributed)
- Different medium

For this example, for successful communication to occur, we will need a mechanism to enable distributed communication. The mechanism will need to define some form of protocol (agreed upon rules) and will also need to do some form of encoding and decoding of messages sent between the _Sender_ and the _Receiver_. This can be seen as illustrated in the diagram below.

![grpc-comms-2](https://user-images.githubusercontent.com/33935506/73964489-280b8180-4977-11ea-8691-bdfac793247d.png)

Now imagine that we simply replace the 2 people with 2 computing systems. A _Client_ and a _Server_. The _Client_ may be a _NodeJS Console Application_ written in Javascript. The _Server_ could be running a _C# .NET_ application. We have 2 separate systems that are running in different data centers and connected via a network. In other words we have a distributed computing system. In order for the _Client_ and the _Server_ to communicate, a _mechanism_ with a _protocol_ will need to be used. _Protocol Buffers (Protobuf)_ and _gRPC_ are just such a mechanism. The diagram below illustrates how our basic communication model can be translated into gRPC clients and server. The clients and server can be completely distributed and running in different data centres in different locations throughout the world.

![grpc-stub-server](https://user-images.githubusercontent.com/33935506/74091899-f2ef6280-4b21-11ea-9b3f-17588e5c8ae0.png)

There have been other solutions that solved this problem too. We are still using some of these at the time of this writing. Http services for example (REST) is still hugely popular. gRPC is simply an alternative to enable communication between distributed services and systems. It's important to remember that although there are different approaches to solving a common problem, the way in which we use these different approaches can be quite different. For example, building and using a Http service is entirely different from building and using a gRPC service.

There is some really good online documentation that describes _gRPC_ and _Protocol Buffers_.

- [gRPC] - The official gRPC website
- [Protocol Buffers] - The official _Google_ developer guide

Because the online documentation is so good, I won't be repeating some of the great work that already been done. Instead, I'm going to focus on the salient points of _[gRPC]_ and _[Protocol Buffers]_. I will also be providing some examples that illustrate how to get started with _gRPC_. All examples will be provided using _[gRPC on .NET Core]_. For more specific documentation relating to building and consuming gRPC services on .NET Core, please see the following great online documentation:

- [gRPC Tutorial: C#]
- [Protocol Buffer Basics: C#]
- [Generated Code: C#]
- [Introduction to gRPC on .NET Core]

## Protocol Buffers

### What?

_Protocol Buffers_ are a mechanism for serializing structured data. They are used by gRPC as the default serialization mechanism.

For more information:

- [Protocol Buffers] - The official _Google_ developer guide
- [Working with Protocol Buffers](https://grpc.io/docs/guides#working-with-protocol-buffers) - Protocol buffers explained on gRPC website

### How?

Because _Protocol Buffers_ are used for serializing structured data, you need to define the structure of the information that you want serialized. We do this by defining protocol buffer message types in a _'.proto'_ file.

For example:

```protobuf
message User {
    string firstName = 1;
    string lastName = 2;
    string email = 3;

    enum AddressType {
        HOME = 0;
        POSTAL = 1;
        WORK = 2;
    }

    message Address {
        string line1 = 1;
        string line2 = 2;
        string region = 3;
        string city = 4;
        string suburb = 5;
        string code = 6;
        AddressType type = 7;        
    }

    repeated Address addresses = 4;
}
```

#### Practice Time

##### 1\. Setup protoc compiler

The most basic way to compile the _'meetings.proto'_ file from above is to use the _'protoc'_ compiler. The _protoc_ compiler is available for a number of different platforms. [See the protobuf release page](https://github.com/protocolbuffers/protobuf/releases). 

If, like me, you're a developer on Debian/Ubuntu and/or Windows, you will find the following online resources useful to install the _protobuf compiler_.

```md
# For Windows using Chocolatey
  
  - Install Chocolatey (https://chocolatey.org/install)

  - Install protoc (https://chocolatey.org/packages/protoc) 
  
    choco install protoc

# For Debian Stretch using apt
  
  - Install protoc (https://packages.debian.org/stretch/protobuf-compiler)
    
    sudo apt install protobuf-compiler

# For Ubuntu Bionic using apt
  
  - Install protoc (https://launchpad.net/ubuntu/bionic/+package/protobuf-compiler)
    
    sudo apt install protobuf-compiler
```

##### 2\. Create 'meetings.proto' file

```protobuf
syntax = "proto3";

package examples;

message User {
    string firstName = 1;
    string lastName = 2;
    string email = 3;

    enum AddressType {
        HOME = 0;
        POSTAL = 1;
        WORK = 2;
    }

    message Address {
        string line1 = 1;
        string line2 = 2;
        string region = 3;
        string city = 4;
        string suburb = 5;
        string code = 6;
        AddressType type = 7;        
    }

    repeated Address addresses = 4;
}

message Meeting {
    repeated User users = 1;
}
```

##### 3\. Compile 'meetings.proto' file

```md
# For Python
protoc -I=. --python_out=. ./meetings.proto

# For Node/Javascript
protoc -I=. --js_out=. ./meetings.proto

# For C#
protoc -I=. --csharp_out=. ./meetings.proto
```

The final step is to use the generated code with your programming language of choice. See more tutorials here:

- [Android](https://grpc.io/docs/tutorials/basic/android)
- [C#](https://grpc.io/docs/tutorials/basic/csharp)
- [C++](https://grpc.io/docs/tutorials/basic/cpp)
- [Dart](https://grpc.io/docs/tutorials/basic/dart)
- [Go](https://grpc.io/docs/tutorials/basic/go)
- [Java](https://grpc.io/docs/tutorials/basic/java)
- [Node](https://grpc.io/docs/tutorials/basic/node)
- [Objective-C](https://grpc.io/docs/tutorials/basic/objective-c)
- [PHP](https://grpc.io/docs/tutorials/basic/php)
- [Python](https://grpc.io/docs/tutorials/basic/python)
- [Ruby](https://grpc.io/docs/tutorials/basic/ruby)
- [Web](https://grpc.io/docs/tutorials/basic/web)

---

## gRPC

gRPC is a free open-source RPC (Remote Procedure Call) framework for building distributed services. According to _[Wikipedia](https://en.wikipedia.org/wiki/Remote_procedure_call)_, RPC can be summarized as follows:

> In distributed computing, a remote procedure call (RPC) is when a computer program causes a procedure (subroutine) to execute in a different address space (commonly on another computer on a shared network), which is coded as if it were a normal (local) procedure call, without the programmer explicitly coding the details for the remote interaction. That is, the programmer writes essentially the same code whether the subroutine is local to the executing program, or remote. This is a form of client–server interaction (caller is client, executor is server), typically implemented via a request–response message-passing system.
>
> -- Wikipedia

_gRPC_ uses _Protocol Buffers_ for communications. Furthermore, _gRPC_ is summarized as follows:

- Designed by Google
- Opensourced in 2015 and now a _[Cloud Native Computing Foundation]_ incubating project
- Ample language support
  - C++
  - Java
  - Python
  - GO
  - C#
  - Node.js
  - Android Java
  - Dart
- A client can execute a method on a server application (on a different machine) as if it was a local object
- A gRPC service is defined by an interface composed of services (methods with parameters and return types) and messages (properties or data with specified types)
- The interface is implemented by the server and runs as a service that accepts calls from remote clients
- The client uses a stub (exact representation of the interface used by the server) to make remote calls to the server
- Servers and clients are platform and language agnostic. This means that one can have a server implemented in Java, but the server can be used by clients that have been implemented in other languages/platforms like Python, Node, C# etc.
- Uses _[Protocol Buffers]_ by default. The protocol buffers can be used as both _Interface Definition Language_ and the underlying message interchange format.

### Why Should You Care About gRPC?

I'm going to share a very opinionated perspective (my opinion) on why you should learn about gRPC.

1\. I think that gRPC is a natural fit for building API's. Because gRPC can help make connecting, executing and debugging distributed systems as easy as making local function calls, it doesn't feel like you're doing anything different to your usual code flow. And it's this ease of use and simplicity that I think makes it feel more natural and easy to use.

2\. gRPC is renowned for it's efficiency (serialization), speed and low latency. Therefore I think it is well suited to building Microservices.

3\. For discussion purposes, I list 3 types of API's that are typically developed:

   - Internal - This means that your API's are accessible from anywhere within a service boundary of your choosing. In other words, internal API's are meant for internal consumption on your private network only.
   - Partner - Partner API's are sort of internal and sort of public. But they are intended as integration points between your applications and services with your Partners applications and services. Typically these API's would be locked down using techniques like VPN and/or IP whitelisting.
   - Public - Anyone on the public internet can access the API

   With the 3 types of API's in mind, I think that initially gRPC is ideal for internal API's. As more companies and developers get hooked on gRPC, I think that the mass adoption will begin to drive the development of gRPC services for Partner and Public API's too.

4\. Having the skills to build gRPC services will serve you well into the future. I think that the popularity of gRPC will continue to grow. Below, I provide a google trend on gRPC for the past 5 years (gRPC was open-sourced in 2015). Note the steady upward trend.
   
   [View gRPC trend here](https://trends.google.com/trends/explore?date=today%205-y&q=grpc)

   ![grpc-trend](https://user-images.githubusercontent.com/33935506/74095914-804fa880-4b5c-11ea-8edc-1ec98c9ed369.png)

---

## Tools

Most developers that work with REST or HTTP services are familiar with the excellent [Postman] tool. _Postman_ is the ideal client tool for interacting with HTTP services. Unfortunately, _Postman_ does not offer support for gRPC .... yet. Luckily for all of us, there is one gRPC client tool worth mentioning. And that tool is _[bloomRPC](https://github.com/uw-labs/bloomrpc)_.

### bloomRPC

GUI Client for gRPC Services 

Features
- Native gRPC calls
- Unary Calls and Server Side Streaming Support
- Client side and Bi-directional Streaming
- Automatic Input recognition
- Multi tabs operations
- Metadata support
- Persistent Workspace
- Request Cancellation

Please checkout the _[bloomRPC](https://github.com/uw-labs/bloomrpc)_ repository and while you're at it, please give them a star. It is well deserving :)

![grpc-bloomgrpc](https://user-images.githubusercontent.com/33935506/74096133-94e17000-4b5f-11ea-81ea-605698d25eb1.png)

### Other

- [.NET Core 3.1 SDK] - .NET Core is a cross-platform version of .NET, for building apps that run on Linux, macOS, and Windows
- [Visual Studio Code] - Visual Studio Code is a source-code editor developed by Microsoft for Windows, Linux and macOS
- [C# for Visual Studio Code] - C# for Visual Studio Code (powered by OmniSharp)
- [vscode-proto3] && [vscode-proto3-ext] - Protobuf 3 support for Visual Studio Code

---

## Examples

### Prerequisites

- [.NET Core 3.1 SDK]
- [Visual Studio Code]
- [C# for Visual Studio Code]

### Tested On

- [Ubuntu 18.04]
- [Ubuntu 18.04 WSL]
- Windows 10

### Messaging Example

This example is a simple messaging application that demonstrates how to create a .NET Core _gRPC Client_ and _gRPC Server_.

By the end of this example, you will have a gRPC Client Console application written in C# that is able to send and receive messages to and from a gRPC Server Console application written in C#. The following concepts will be demonstrated:

- Create a gRPC Client (C# Console Application)
- Create a gRPC Server (C# Console Application)
- Send messages from gRPC Client to gRPC Server

#### 1\. Create Solution

```dos
mkdir grpc-messaging
cd grpc-messaging
dotnet new sln -n Messaging
```

#### 2\. Create 'messaging.proto' file

```bash
# for linux
touch messaging.proto

# for powershell
New-Item -Name messaging.proto
```

Define 'messaging.proto' file

```protobuf
syntax = "proto3";

package messaging;

option csharp_namespace = "Messaging";

message MessageRequest {
    string message = 1;
}

message MessageResponse {
    string message = 1;
}

service Messenger {
    rpc Message (MessageRequest) returns (MessageResponse);
}
```

#### 3\. Create gRPC Server

##### 3\.1 Create the Server Console application

```bash
dotnet new console -n Messaging.ServerApp
dotnet sln Messaging.sln add Messaging.ServerApp
```

##### 3\.2 Add packages required to create gRPC Server

```bash
cd Messaging.ServerApp
dotnet add package gRPC
dotnet add package gRPC.Tools
dotnet add package Google.Protobuf

dotnet list package

Project 'Messaging.ServerApp' has the following package references
   [netcoreapp3.1]:
   Top-level Package      Requested   Resolved
   > Google.Protobuf      3.11.3      3.11.3
   > gRPC                 2.27.0      2.27.0
   > gRPC.Tools           2.27.0      2.27.0
```

##### 3\.3 Create a 'Services' folder

```bash
mkdir Services
```

##### 3\.4 Edit Messaging.ServerApp.csproj file

We need to add the following _'ItemGroup'_ to _Messaging.ServerApp.csproj_ to enable the appropriate code generation for our gRPC server.

```xml
<ItemGroup>
    <Protobuf Include="../*.proto" GrpcServices="Server" OutputDir="%(RelativePath)Services" CompileOutputs="false" />
</ItemGroup>
```

```md
- Include="../*.proto" - Include all '.proto' files for code generation
- GrpcServices="Server" - Only generate code relevant to server
- OutputDir="%(RelativePath)Services" - path for generated files
- CompileOutputs="false" - prevents compiling generated files into assembly
```

The resulting _Messaging.ServerApp.csproj_ file should look as follows:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <Protobuf Include="../*.proto" GrpcServices="Server" OutputDir="%(RelativePath)Services" CompileOutputs="false" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Google.Protobuf" Version="3.11.3" />
    <PackageReference Include="gRPC" Version="2.27.0" />
    <PackageReference Include="gRPC.Tools" Version="2.27.0">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>

</Project>
```

##### 3\.5 Build Solution

```bash
# Build from the root of solution
cd ..
dotnet build
```

After the build, you should see a solution structure as follows. Take note of the 2 generate files in the 'Services' folder.

- Messaging.cs
- MessagingGrpc.cs

![grpc-server-solution](https://user-images.githubusercontent.com/33935506/73978257-dcfe6800-4990-11ea-8706-4a428f9fb64f.png)

##### 3\.6 Create 'MessengerService'

Create a Service that implements the generated gRPC 'MessengerBase' code

```csharp
using System.Threading.Tasks;
using Grpc.Core;

namespace Messaging.ServerApp
{
    public sealed class MessengerService : Messenger.MessengerBase
    {
        public override Task<MessageResponse> Message(MessageRequest request, ServerCallContext context)
        {
            return Task.FromResult(new MessageResponse
            {
                Message = $"This is your friendly gRPC Server. Received message: '{request.Message}'"
            });
        }
    }
}
```

##### 3\.7 Update 'Program.cs' to run server

```csharp
using System;
using System.IO;
using System.Threading.Tasks;
using Grpc.Core;

namespace Messaging.ServerApp
{
    internal sealed class Program
    {
        internal static async Task Main(string[] args)
        {
            const int Port = 50050;

            Server server = null;
            
            try
            {
                server = new Server
                {
                    Services = { Messenger.BindService(new MessengerService()) },
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure ) }
                };

                server.Start();

                Console.WriteLine($"Messenger server listening on port {Port}");
                Console.WriteLine("Press any key to stop the server...");
                Console.ReadKey();
            }
            catch(IOException exception)
            {
                Console.WriteLine($"Server failed to start: {exception.Message}");
                throw;
            }
            finally
            {
                if (server != null)
                    await server.ShutdownAsync();
            }
        }
    }
}
```

##### 3\.8 Run the gRPC Server

```bash
dotnet run -p Messaging.ServerApp

# You should see the following response
Messenger server listening on port 50050
Press any key to stop the server...
```

#### 4\. Create gRPC Client

##### 4\.1 Create the Client Console application

```bash
# From the root of solution

dotnet new console -n Messaging.ClientApp
dotnet sln Messaging.sln add Messaging.ClientApp
```

##### 4\.2 Add packages required to create gRPC Client

```bash
cd Messaging.ClientApp
dotnet add package gRPC
dotnet add package gRPC.Tools
dotnet add package Google.Protobuf

dotnet list package

Project 'Messaging.ClientApp' has the following package references
   [netcoreapp3.1]:
   Top-level Package      Requested   Resolved
   > Google.Protobuf      3.11.3      3.11.3
   > gRPC                 2.27.0      2.27.0
   > gRPC.Tools           2.27.0      2.27.0
```

##### 4\.3 Create a 'Services' folder

```bash
mkdir Services
```

##### 4\.4 Edit Messaging.ClientApp.csproj file

We need to add the following _'ItemGroup'_ to _Messaging.ClientApp.csproj_ to enable the appropriate code generation for our gRPC Client.

```xml
<ItemGroup>
    <Protobuf Include="../*.proto" GrpcServices="Client" OutputDir="%(RelativePath)Services" CompileOutputs="false" />
</ItemGroup>
```

```md
- Include="../*.proto" - Include all '.proto' files for code generation
- GrpcServices="Client" - Only generate code relevant to Client
- OutputDir="%(RelativePath)Services" - path for generated files
- CompileOutputs="false" - prevents compiling generated files into assembly
```

The resulting _Messaging.ClientApp.csproj_ file should look as follows:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <Protobuf Include="../*.proto" GrpcServices="Client" OutputDir="%(RelativePath)Services" CompileOutputs="false" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Google.Protobuf" Version="3.11.3" />
    <PackageReference Include="gRPC" Version="2.27.0" />
    <PackageReference Include="gRPC.Tools" Version="2.27.0">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>

</Project>
```

##### 4\.5 Build Solution

```bash
# Build from the root of solution
cd ..
dotnet build
```

After the build, you should see a solution structure as follows. Take note of the 2 generate files in the 'Services' folder.

- Messaging.cs
- MessagingGrpc.cs

![grpc-client-solution](https://user-images.githubusercontent.com/33935506/73985150-4dac8100-499f-11ea-8d14-e8a97e28301d.png)

##### 4\.6 Update 'Program.cs' to run Client

```csharp
using Grpc.Core;
using Messaging;
using System;
using System.Threading.Tasks;

namespace Messaging.ClientApp
{
    internal sealed class Program
    {
        internal static async Task Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50050", ChannelCredentials.Insecure);

            var client = new Messenger.MessengerClient(channel);
            var reply = client.Message(new MessageRequest { Message = "These are not the droids you are looking for ..." });
            Console.WriteLine("Message: " + reply.Message);

            await channel.ShutdownAsync();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
```

##### 4\.7 Run the gRPC Client

```bash
dotnet run -p Messaging.ClientApp

# You should see the following response
Message: This is your friendly gRPC Server. Received message: 'These are not the droids you are looking for ...'
Press any key to exit...
```

#### Solution

The full solution can be found [here](https://github.com/drminnaar/grpc-guide/tree/master/examples/messaging).

### Calculator Example

Now it's your turn. Create a gRPC Calculator service that provides the following arithmetic operations:

- Add
- Subtract
- Multiply
- Divide

#### Solution

The full solution can be found [here](https://github.com/drminnaar/grpc-guide/tree/master/examples/calculator).

##### Proto File

```protobuf
syntax = "proto3";
package calculators;
option csharp_namespace = "Calculators";

message OperationRequest {
    repeated double operands = 1;
}

message OperationResponse {
    double result = 1;
}

message DivisionRequest {
    double dividend = 1;
    double divisor = 2;
}

message DivisionResponse {
    double result = 1;
}

service Calculator {
    rpc Add (OperationRequest) returns (OperationResponse);
    rpc Subtract (OperationRequest) returns (OperationResponse);
    rpc Multiply (OperationRequest) returns (OperationResponse);
    rpc Divide (DivisionRequest) returns (DivisionResponse);
}
```

##### gRPC Calculator Server

```csharp
/// ########################
/// CalculatorService
/// ########################

using Grpc.Core;
using System.Linq;
using System.Threading.Tasks;

namespace Calculators.ServerApp
{
    public sealed class CalculatorService : Calculator.CalculatorBase
    {
        public override Task<OperationResponse> Add(OperationRequest request, ServerCallContext context)
        {
            return Task.FromResult(new OperationResponse
            {
                Result = request.Operands.Sum()
            });
        }

        public override Task<DivisionResponse> Divide(DivisionRequest request, ServerCallContext context)
        {
            return Task.FromResult(new DivisionResponse
            {
                Result = request.Dividend / request.Divisor
            });
        }

        public override Task<OperationResponse> Multiply(OperationRequest request, ServerCallContext context)
        {
            return Task.FromResult(new OperationResponse
            {
                Result = request.Operands.Aggregate((acc, operand) => acc *= operand)
            });
        }

        public override Task<OperationResponse> Subtract(OperationRequest request, ServerCallContext context)
        {
            return Task.FromResult(new OperationResponse
            {
                Result = request.Operands.Aggregate((acc, operand) => acc -= operand)
            });
        }
    }
}

```

```csharp
/// ########################
/// Program
/// ########################

using System;
using System.IO;
using System.Threading.Tasks;
using Grpc.Core;

namespace Calculators.ServerApp
{
    internal sealed class Program
    {
        internal static async Task Main(string[] args)
        {
            const int Port = 50050;

            Server server = null;

            try
            {
                server = new Server
                {
                    Services = { Calculator.BindService(new CalculatorService()) },
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                };

                server.Start();

                Console.WriteLine($"Calculator server listening on port {Port}");
                Console.WriteLine("Press any key to stop the server...");
                Console.ReadKey();
            }
            catch (IOException exception)
            {
                Console.WriteLine($"Server failed to start: {exception.Message}");
                throw;
            }
            finally
            {
                if (server != null)
                    await server.ShutdownAsync();
            }
        }
    }
}

```

##### gRPC Calculator Client

```csharp
/// ########################
/// Program
/// ########################

using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace Calculators.ClientApp
{
    internal sealed class Program
    {
        internal static async Task Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50050", ChannelCredentials.Insecure);

            var client = new Calculator.CalculatorClient(channel);
            var operands = new double[5] { 1D, 2D, 3D, 4D, 5D };

            var addRequest = new OperationRequest();
            addRequest.Operands.AddRange(operands);

            var subtractRequest = new OperationRequest();
            subtractRequest.Operands.AddRange(operands);

            var multiplicationRequest = new OperationRequest();
            multiplicationRequest.Operands.AddRange(operands);

            var divisionRequest = new DivisionRequest
            {
                Dividend = 45,
                Divisor = 5
            };

            var sum = await client.AddAsync(addRequest);
            var difference = await client.SubtractAsync(subtractRequest);
            var product = await client.MultiplyAsync(multiplicationRequest);
            var division = await client.DivideAsync(divisionRequest);

            Console.WriteLine($"Sum: {sum.Result}, Difference: {difference.Result}, Product: {product.Result}, Division: {division.Result}");

            await channel.ShutdownAsync();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
```

---

## Where To From Here?

I've only introduced the gRPC and Protocol Buffer fundamentals in this guide. I'd recommend doing some online digging for information relating to your platform/language of choice. For example, I only spoke about _Unary_ communication in this guide. Be sure to do some research on other alternatives like:

- Server streaming
- Client streaming
- Bi-directional streaming

I'm looking forward to feedback from the community to see if there is any way that I can help developers learn more about gRPC. I will then most likely explore a number of follow-up topics for future posts.

gRPC for the win :trophy:


[gRPC]: https://grpc.io/
[gRPC Tutorial: C#]: https://grpc.io/docs/tutorials/basic/csharp/
[Protocol Buffer Basics: C#]: https://developers.google.com/protocol-buffers/docs/csharptutorial
[Protocol Buffers]: https://developers.google.com/protocol-buffers/docs/overview
[Generated Code: C#]: https://developers.google.com/protocol-buffers/docs/reference/csharp-generated
[Protobuf Compiler: Ubuntu]: https://packages.ubuntu.com/bionic/protobuf-compiler
[Protobuf Compiler: Windows]: https://chocolatey.org/packages/protoc
[Chocolatey]: https://chocolatey.org/
[Chocolatey Install]: https://chocolatey.org/install
[Introduction to gRPC on .NET Core]: https://docs.microsoft.com/en-us/aspnet/core/grpc/?view=aspnetcore-3.1
[gRPC on .NET Core]: https://docs.microsoft.com/en-us/aspnet/core/grpc/?view=aspnetcore-3.1
[Cloud Native Computing Foundation]: https://cncf.io/
[CNCF]: https://cncf.io/
[.NET Core]: https://dotnet.microsoft.com/download/dotnet-core/3.1
[.NET Core 3.1]: https://dotnet.microsoft.com/download/dotnet-core/3.1
[.NET Core 3.1 SDK]: https://dotnet.microsoft.com/download/dotnet-core/3.1
[Visual Studio Code]: https://code.visualstudio.com/download
[C# for Visual Studio Code]: https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp
[Ubuntu 18.04]: https://ubuntu.com/download/desktop
[Ubuntu 18.04 WSL]: https://docs.microsoft.com/en-us/windows/wsl/install-manual
[vscode-proto3]: https://github.com/zxh0/vscode-proto3
[vscode-proto3-ext]: https://marketplace.visualstudio.com/items?itemName=zxh404.vscode-proto3
[Messenger]: https://github.com/drminnaar/grpc-guide/tree/master/examples/messaging
[Calculator]: https://github.com/drminnaar/grpc-guide/tree/master/examples/calculator