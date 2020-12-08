# [3.0.0](https://github.com/informatievlaanderen/event-handling/compare/v2.4.1...v3.0.0) (2020-12-08)


### Bug Fixes

* change EventTagsAttribute to strong type ([f5a72b4](https://github.com/informatievlaanderen/event-handling/commit/f5a72b4ea1001267de036d049bc8d2a6476c79a3))


### Features

* add generating markdown for specific tags ([35f29b3](https://github.com/informatievlaanderen/event-handling/commit/35f29b3833a8a3ec99c335c2141344c0540149b5))
* generate markdown for a multiple generators ([acabd3b](https://github.com/informatievlaanderen/event-handling/commit/acabd3b20fd38ded75ffd822e37ade73371521af))


### BREAKING CHANGES

* CHANGES
added function to the public Interface
* CHANGE
removed the WriteTo function from the interface
created extension on collection of generators
* CHANGE
Tags property type is changed from string[] to IEnumerable<EventTag>

## [2.4.1](https://github.com/informatievlaanderen/event-handling/compare/v2.4.0...v2.4.1) (2020-12-02)


### Bug Fixes

* remove empty lines when no event description is set GRAR-1613 ([4d979f1](https://github.com/informatievlaanderen/event-handling/commit/4d979f1023f0ece118c2a2016faeaa6654f2c8d8))

# [2.4.0](https://github.com/informatievlaanderen/event-handling/compare/v2.3.1...v2.4.0) (2020-11-27)


### Features

* add markdown generator for event documentation ([7a13003](https://github.com/informatievlaanderen/event-handling/commit/7a130038b6b88f3801200c65393dd7c602c14958))

## [2.3.1](https://github.com/informatievlaanderen/event-handling/compare/v2.3.0...v2.3.1) (2020-11-18)


### Bug Fixes

* remove set-env usage in gh-actions ([5febd9d](https://github.com/informatievlaanderen/event-handling/commit/5febd9d43045e962469a5657c8ab51bf605a9f17))

# [2.3.0](https://github.com/informatievlaanderen/event-handling/compare/v2.2.6...v2.3.0) (2020-10-27)


### Features

* add EventPropertyDescription and EventTags attributes ([d78ed05](https://github.com/informatievlaanderen/event-handling/commit/d78ed0517138a557ec45bf57635062e630bf066e))

## [2.2.6](https://github.com/informatievlaanderen/event-handling/compare/v2.2.5...v2.2.6) (2020-09-21)


### Bug Fixes

* move to 3.1.8 ([071b209](https://github.com/informatievlaanderen/event-handling/commit/071b209306618143b037acfe5d2590fb75b0902a))

## [2.2.5](https://github.com/informatievlaanderen/event-handling/compare/v2.2.4...v2.2.5) (2020-07-18)


### Bug Fixes

* move to 3.1.6 ([d16fa4a](https://github.com/informatievlaanderen/event-handling/commit/d16fa4adf39e7d63bba4a2662ca86169a2f2ead2))

## [2.2.4](https://github.com/informatievlaanderen/event-handling/compare/v2.2.3...v2.2.4) (2020-06-19)


### Bug Fixes

* move to 3.1.5 ([1e83361](https://github.com/informatievlaanderen/event-handling/commit/1e83361a446d6457f1e0b82c7a168f035bcf5fc0))

## [2.2.3](https://github.com/informatievlaanderen/event-handling/compare/v2.2.2...v2.2.3) (2020-05-18)


### Bug Fixes

* move to 3.1.4 ([4a8323a](https://github.com/informatievlaanderen/event-handling/commit/4a8323a04f410a3a458998ab6ba8f023ccff889d))

## [2.2.2](https://github.com/informatievlaanderen/event-handling/compare/v2.2.1...v2.2.2) (2020-05-04)


### Bug Fixes

* move to GH-actions ([308b53e](https://github.com/informatievlaanderen/event-handling/commit/308b53e082a6827e132870c4adf93cceb6fd71d3))

## [2.2.1](https://github.com/informatievlaanderen/event-handling/compare/v2.2.0...v2.2.1) (2020-03-03)


### Bug Fixes

* bump netcore to 3.1.2 ([3107d4b](https://github.com/informatievlaanderen/event-handling/commit/3107d4b3a8ae295735ccfd98c9e3b5cc16cb09ff))

# [2.2.0](https://github.com/informatievlaanderen/event-handling/compare/v2.1.0...v2.2.0) (2020-01-31)


### Features

* upgrade netcoreapp31 and dependencies ([74172ed](https://github.com/informatievlaanderen/event-handling/commit/74172ed1b0cc4be88cede7966fbf5fd0fe7d346d))

# [2.1.0](https://github.com/informatievlaanderen/event-handling/compare/v2.0.0...v2.1.0) (2019-12-15)


### Features

* upgrade to netcoreapp31 ([bbfb995](https://github.com/informatievlaanderen/event-handling/commit/bbfb995f03e76272f27613638e9e96e1f9eba134))

# [2.0.0](https://github.com/informatievlaanderen/event-handling/compare/v1.3.0...v2.0.0) (2019-11-22)


### Code Refactoring

* upgrade to netcoreapp30 ([53c094a](https://github.com/informatievlaanderen/event-handling/commit/53c094a))


### BREAKING CHANGES

* Upgrade to .NET Core 3

# [1.3.0](https://github.com/informatievlaanderen/event-handling/compare/v1.2.0...v1.3.0) (2019-09-26)


### Features

* **eventmapping:** add has event name and has event type ([f3f9a1b](https://github.com/informatievlaanderen/event-handling/commit/f3f9a1b))

# [1.2.0](https://github.com/informatievlaanderen/event-handling/compare/v1.1.1...v1.2.0) (2019-09-26)


### Features

* **eventmapping:** adds try get event name and try get event type ([bc1091e](https://github.com/informatievlaanderen/event-handling/commit/bc1091e))

## [1.1.1](https://github.com/informatievlaanderen/event-handling/compare/v1.1.0...v1.1.1) (2019-08-22)


### Bug Fixes

* use correct nuget dependencies ([29273c2](https://github.com/informatievlaanderen/event-handling/commit/29273c2))

# [1.1.0](https://github.com/informatievlaanderen/event-handling/compare/v1.0.3...v1.1.0) (2019-08-22)


### Features

* bump to .net 2.2.6 ([82a19d4](https://github.com/informatievlaanderen/event-handling/commit/82a19d4))

## [1.0.3](https://github.com/informatievlaanderen/event-handling/compare/v1.0.2...v1.0.3) (2019-04-25)

## [1.0.2](https://github.com/informatievlaanderen/event-handling/compare/v1.0.1...v1.0.2) (2019-04-24)

## [1.0.1](https://github.com/informatievlaanderen/event-handling/compare/v1.0.0...v1.0.1) (2018-12-18)

# 1.0.0 (2018-12-16)


### Features

* open source with MIT license as 'agentschap Informatie Vlaanderen' ([8d954db](https://github.com/informatievlaanderen/event-handling/commit/8d954db))
