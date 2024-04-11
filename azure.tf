provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "cloudsolution" {
  name     = "cloudsolution"
  location = "East US" 
}

resource "azurerm_app_service_plan" "container_app_plan" {
  name                = "container-app-plan"
  location            = azurerm_resource_group.cloudsolution.location
  resource_group_name = azurerm_resource_group.cloudsolution.name
  kind                = "Linux"
  reserved            = true

  sku {
    tier = "Basic"
    size = "B1"
  }
}

resource "azurerm_container_registry" "acr" {
  name                     = "your-container-registry" 
  resource_group_name      = azurerm_resource_group.cloudsolution.name
  location                 = azurerm_resource_group.cloudsolution.location
  sku                      = "Basic"
  admin_enabled            = false
}

resource "azurerm_app_service" "container_app" {
  name                = "container-app"
  location            = azurerm_resource_group.cloudsolution.location
  resource_group_name = azurerm_resource_group.cloudsolution.name
  app_service_plan_id = azurerm_app_service_plan.container_app_plan.id

  site_config {
    always_on                 = true
    linux_fx_version          = "DOCKER|<your-acr-name>.azurecr.io/<your-container-image>:<tag>"  
    app_command_line          = ""
    ftps_state                = "Disabled"
    use_32_bit_worker_process = false
    websockets_enabled        = false
  }

  logs {
    http_logs {
      file_system {
        retention_in_days = 7
        retention_in_mb   = 100
      }
    }
  }

  identity {
    type = "SystemAssigned"
  }
}

output "container_app_url" {
  value = azurerm_app_service.container_app.default_site_hostname
}