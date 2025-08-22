# Welcome to SolrInstanceManager

## Overview

This project aim to provide easy way to manage the Solr instances on your machine.

Each Solr instance managed by SolrInstanceManager should be registered first.

## Project structure

> Each project should contains a `readme.md` file as its documentation

### Kernel

The core of this project. Each feature or function that are not platform specific should be implemented here

### CLI

The Command Line Interface for interacting with SolrInstanceManager via command line.

> The project with `UI.` prefix is the UI project but at different variant.
> For example: `UI.Desktop` is a UI project for desktop (Windows, Mac, or Linux)

### UI.Desktop

The desktop implementation of Solr Instance Manager. Despite it is written in Avalonia and is cross-platform ready, we will focus this project on Windows at the moment. Any support on other platform (Linux or Mac) is not available at the moment until further notice.
