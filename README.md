# Goodreads .NET API Client Library

A Goodreads .NET API Client Library.

# Usage Examples

```csharp
// Create an API client
var client = new GoodreadsClient("api_key");

// Retrieve an author
var author = await client.Authors.Get(38550);

// Retrieve a book
var book = await client.Books.GetByIsbn("0441172717");

// Retrieve a paginated list of an author's books
var books = await client.Books.GetListByAuthorId(38550, page: 2);

// Retrieve a paginated list of a user's shelves
var shelves = await client.Shelves.GetUserShelves(userId, page: 2);
```

# License

The MIT License (MIT)

Copyright (c) 2016 Adam Krogh

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
