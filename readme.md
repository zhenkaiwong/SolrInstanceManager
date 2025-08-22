# Welcome to SolrInstanceManager

## Overview

This project aim to provide easy way to manage the Solr instances on your machine.

Each Solr instance managed by SolrInstanceManager should be registered first.

## Project structure

> Each project should contains a `readme.md` file as its documentation

> The project with `UI.` prefix is the UI project but at different variant.
> For example: `UI.Desktop` is a UI project for desktop (Windows, Mac, or Linux)

### Kernel

The core of this project. Each feature or function that are not platform specific should be implemented here

### CLI

The Command Line Interface for interacting with SolrInstanceManager via command line.

### UI.Desktop

The desktop implementation of Solr Instance Manager. Despite it is written in Avalonia and is cross-platform ready, we will focus this project on Windows at the moment. Any support on other platform (Linux or Mac) is not available at the moment until further notice.

## Tests

All tests are available under `/Tests` folder. The following are the descriptions of each available test:

### Kernel/UnitTests

Unit tests for kernel. The tests included in this project should not contains testing the integration with file resources / Solr. To add such test, please use `Kernel/IntegrationTests`

### Kernel/IntegrationTests

Integration tests for kernel. All tests for integration with file resources / Solr should be included in this test project.
