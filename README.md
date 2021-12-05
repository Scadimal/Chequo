# Welcome to the readme

## What IS this

### Project as a whole
The purpose of this project is to convert numerical digits into English. This can be achieved via an API endpoint.
In addition to this, a simple front-end was put together to utilise this API.

### Regarding Svelte
After talking about svelte in our first interview, I decided it would be interesting to learn a bit about it. Since you asked me to make a simple front-end app, I figured it would be a good opportunity to try it out! The front is extremely basic, and could be more-so. Rather than just have the number getting converted to text, I decided to explore a bit of
- Stores in svelte (Could absolutely do without this, but it's more interesting)
- Forms in svelte (And how we can bind props and so-forth)
- Derived variables
- Components

While this could all have been achieved easily without any of the above, since this was to showcase skills I figured it would be more beneficial (Hopefully that's okay)

## Built With
- Svelte
- TypeScript
- .NET 5.0

## Getting Started
In order to use this, you're going to need npm, and dotnet.

Firstly, you should begin the .NET project by using `dotnet run` from the core directory. If you've modified the build, update it using dotnet build.

Once you have that sorted, navigate to the `svelte` directory. Here you can start your dev environment for svelte with `npm run dev`.

By default it will be hosted at http://localhost:5000. If you wish to change this, you will also need
to modify the middleware in the .NET api to allow CORS from the new location.
Also ensure that the .NET project is accessible via port 5001.

## Usage
Once both projects are running, use this project via the svelte project at http://localhost:5000
OR you could test the API directly through http requests to https://localhost:5001
