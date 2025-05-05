pipeline {
    agent any

    environment {
        DOTNET_ROOT = '/usr/share/dotnet' // Optional, depends on your setup
        PATH = "/usr/share/dotnet:${env.PATH}" // Ensure dotnet is in PATH
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
            junit allowEmptyResults: true, testResults: '**/TestResults/*.trx'
        }
    }
}
