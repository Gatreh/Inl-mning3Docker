#!/bin/bash

resource_group=docker3
location=northeurope
vm_name=docker3
vm_port=80

az group create --location $location --name $resource_group

az vm create --name $vm_name --resource-group $resource_group \
             --image Ubuntu2204 --size Standard_B1s \
             --generate-ssh-keys --admin-username azureuser \
             --custom-data @cloud-init_docker.yaml

az vm open-port --port $vm_port --resource-group $resource_group --name $vm_name