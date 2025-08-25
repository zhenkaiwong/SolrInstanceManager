# CLI of SolrInstanceManager

## Overview

This project contains the CLI implementation of SolrInstanceManager. The aim of this project is to provide CLI-based interaction with SolrInstanceManager.

> 🚨 Current version of SolrInstanceManager only support local Solr instances with hostname `localhost`. It will use `localhost` to make request to your Solr instance by default

## Tech stack

- .NET
- C#

## File structure

- `AppSettings.json`: Contains the configurable settings for application. Check [Appendix 1](#Appendix-1) for the content structure
- `solrentries.json`: Contains all the registered Solr instances. Check [Appendix 2](#Appendix-2) for the content structure
- `/solrpackages`: The cache folder for downloaded Solr packages. Application will first determine if the required version of Solr package exists in this folder first before it attempts to download it from source
- `/certificates`: This folder contains all certificates created and installed by SolrInstanceManager for your Solr instance with `-https` parameter presented in `create-instance` command

## Usage

### List registered Solr instances

```bash
list
```

This command list all Solr instances that are registered with the application

### Create a Solr instance

```bash
create-instance -name <name of your Solr instance> -dir <solr root directory> -port <port number> -version <version of Solr> [-service <service name of Solr instance>] [-https] [-cloud]
```

This command create a Solr instance on your machine and use the provided parameters to configure it, then register it in `solrentries.json`. Use this when you want to set up a fresh installation of Solr

Each solr instance should have a unique name in entries. Application should not proceed with the create operation if it determine a duplicated name is provided

Optional parameters:

- -service
- -https: If specified, a certificate will be created under `/certificates` and installed, then enable SSL in your Solr instance
- -cloud: Setup SolrCloud instead if specified

### Register an existing Solr instance

```bash
register-instance -name <name of your Solr instance> -dir <solr root directory> -port <port number> [-service <service name of Solr instance>]
```

This command register an existing Solr instance with the application. Use this when you already have a Solr instance and you wish to manage it with SolrInstanceManager

Optional parameters:

- -service

> 🚨 Solr instance registration don't require specifying following parameters. The application determines them by sending request to your Solr instance
>
> - -https: Application should not proceed with the registration if it determine the Solr instance isn't accessible through either HTTP or HTTPs
> - -cloud
> - -version

### Update Solr instance registration

```bash
update-instance -name <name of your Solr instance> [-dir <solr root directory>] [-port <port number>] [-service <service name of Solr instance>] [-https <true|false>]
```

This command update the registered Solr instance in `solrentries.json` with the provided parameters

Each solr instance should have a unique name in entries. Application should not proceed with the update operation if it determine a duplicated name is provided

Optional parameters:

- -dir
- -port
- -service
- -https: A boolean value to determine whether or not to enable / disable HTTPs on your existing Solr instance. If your Solr instance have never been configured with SSL, application will create a certificate, install it, and configure it with your Solr instance, if the provided value for this parameter is `true`

> 🚨 While you can specify no optional parameters for this command, the `update-instance` command will not perform anything in such case

> 🚨 Updating the version and mode isn't supported. Please consider to create a new instance instead.

### Remove registered Solr instance

```bash
remove-instance -name <name of your Solr instance> [-removeAll]
```

This command remove a registered Solr instance from `solrentries.json`. Application should not proceed with the remove operation if the provided name isn't found in `solrentries.json`

Optional parameters:

- -removeAll: If specified, remove the Solr directory, SSL certificate, and service from your machine

## Appendices

### Appendix 1

```json
{
    "downloadSource": "https://"
    "sitecore": {
        "enabled": false,
        "default": false
    }
}
```

> 🚨 Above is just an example. It doesn't represent the default content in `appsettings.json`

- `downloadSource`: The source where application download Solr package
- `sitecore.enabled`: A boolean value that determine whether or not to prompt for confirmation to setup Solr instance for Sitecore during `create-instance` command
- `sitecore.default`: A boolean value that determine whether or not to setup Solr instance for Sitecore by default. `sitecore.enabled` must be `true` as well if this setting is enabled. Application will not setup Solr instance for Sitecore if `sitecore.enabled` is `false`. Enabling this setting will skip the confrmation during `create-instance` command

### Appendix 2

```json
[
  {
    "name": "Solr 9.8.1",
    "dir": "C:/solr-9.8.1",
    "port": 8983,
    "service": "solr981",
    "https": true
    "isCloud": false
    "version": "9.8.1"
  }
]
```

> 🚨 Above is just an example. It doesn't represent the default content in `solrentries.json`

- `name`: Name of registered Solr instance
- `dir`: Root directory of Solr instance
- `port`: Port number to access Solr instance
- `service`: **Optional**: Name of the service associated with an Solr instance
- `https`: A boolean value to indicate whether or not Solr instance can be accessed through HTTPs
- `isCloud`: A boolean value to indicate whether or not its mode is either Solr standalone or Solr Cloud. `true` if its mode is Solr Cloud. `false` if its mode is Solr standard
- `version`: Version of the Solr instance
