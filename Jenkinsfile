pipeline {
    agent any

    environment {
        DOTNET_ROOT = '/usr/share/dotnet'
    }

    tools {
        // This name must match the .NET SDK installed in Jenkins global tool config
        dotnet 'dotnet6' 
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore RestSharpApiTests/RestSharpApiTests.csproj'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build RestSharpApiTests/RestSharpApiTests.csproj --configuration Release'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test RestSharpApiTests/RestSharpApiTests.csproj --logger "trx;LogFileName=test_results.trx"'
            }
        }
    }

    post {
        always {
            // Publishes NUnit-compatible test reports (for HTML UI in Jenkins)
            junit allowEmptyResults: true, testResults: '**/TestResults/*.trx'
        }
    }
}
