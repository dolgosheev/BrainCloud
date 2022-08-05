[![Bugs](https://test.paradox-server.ru/api/project_badges/measure?project=CatalogService&metric=bugs&token=d98c0ce3872136bc4b0449e655859295a516edbf)](https://test.paradox-server.ru/dashboard?id=BrainCloud)

[![Code Smells](https://test.paradox-server.ru/api/project_badges/measure?project=CatalogService&metric=code_smells&token=d98c0ce3872136bc4b0449e655859295a516edbf)](https://test.paradox-server.ru/dashboard?id=BrainCloud)

[![Coverage](https://test.paradox-server.ru/api/project_badges/measure?project=CatalogService&metric=coverage&token=d98c0ce3872136bc4b0449e655859295a516edbf)](https://test.paradox-server.ru/dashboard?id=BrainCloud)

[![Duplicated Lines (%)](https://test.paradox-server.ru/api/project_badges/measure?project=CatalogService&metric=duplicated_lines_density&token=d98c0ce3872136bc4b0449e655859295a516edbf)](https://test.paradox-server.ru/dashboard?id=BrainCloud)

[![Lines of Code](https://test.paradox-server.ru/api/project_badges/measure?project=CatalogService&metric=ncloc&token=d98c0ce3872136bc4b0449e655859295a516edbf)](https://test.paradox-server.ru/dashboard?id=BrainCloud)

[![Maintainability Rating](https://test.paradox-server.ru/api/project_badges/measure?project=CatalogService&metric=sqale_rating&token=d98c0ce3872136bc4b0449e655859295a516edbf)](https://test.paradox-server.ru/dashboard?id=BrainCloud)

[![Quality Gate Status](https://test.paradox-server.ru/api/project_badges/measure?project=CatalogService&metric=alert_status&token=d98c0ce3872136bc4b0449e655859295a516edbf)](https://test.paradox-server.ru/dashboard?id=BrainCloud)

[![Reliability Rating](https://test.paradox-server.ru/api/project_badges/measure?project=CatalogService&metric=reliability_rating&token=d98c0ce3872136bc4b0449e655859295a516edbf)](https://test.paradox-server.ru/dashboard?id=BrainCloud)

[![Security Rating](https://test.paradox-server.ru/api/project_badges/measure?project=CatalogService&metric=security_rating&token=d98c0ce3872136bc4b0449e655859295a516edbf)](https://test.paradox-server.ru/dashboard?id=BrainCloud)

[![Technical Debt](https://test.paradox-server.ru/api/project_badges/measure?project=CatalogService&metric=sqale_index&token=d98c0ce3872136bc4b0449e655859295a516edbf)](https://test.paradox-server.ru/dashboard?id=BrainCloud)

[![Vulnerabilities](https://test.paradox-server.ru/api/project_badges/measure?project=CatalogService&metric=vulnerabilities&token=d98c0ce3872136bc4b0449e655859295a516edbf)](https://test.paradox-server.ru/dashboard?id=BrainCloud)



### Description
Solution contains some userful things

*it was made just for education*

<hr>

## AsynchronousOperations ( .net6 ) ##
### used classes ###
> - Timer 
> - Parallel
> - Asynchronous operations
> - Enumerable
> - Linq (Aggregate)

<hr>

## Generator ( .net6 ) ##
### used classes ###
> - Benchmark ( [MemoryDiagnoser] )
> - Enumerable

### Result ± ###
```
|               Method |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
|--------------------- |---------:|----------:|----------:|-------:|----------:|
|           'Use Span' | 8.981 us | 0.1562 us | 0.1219 us | 3.8452 |      8 KB |
| 'Use Array & Concat' | 9.800 us | 0.1916 us | 0.4736 us | 3.3875 |      7 KB |

```

<hr>

## NetworkInfo ( .net6 ) ##
### used classes ###
> - IPGlobalProperties 
> - NetworkInterface
> - StringBuilder
> - Linq (ForEach)


<hr>

## CollectionObserve ( .net6 ) ##
### used classes ###
> - ObservableCollection
> - NotifyCollectionChangedEventArgs

##### Helpful links
[must have Metanit](https://metanit.com/) | 
[must have Microsoft](https://docs.microsoft.com/ru-ru/dotnet/api/) | 
[.net Snippets](https://www.dotnetperls.com/) | 
[brain killer](http://rosettacode.org/wiki/Category:Programming_Tasks/)