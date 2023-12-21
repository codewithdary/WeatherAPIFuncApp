# Variables
$resourceGroupName = "rgBicepTestDeploy"
$bicepFilePath = "deploy.bicep"


# Login to Azure (if not already logged in)
az login


az group create --name $resourceGroupName --location "eastus"

# Deploy the Bicep file
az deployment group create `
  --resource-group $resourceGroupName `
  --template-file $bicepFilePath `
 
