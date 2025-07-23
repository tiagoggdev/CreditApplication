pipeline {
  agent any

  environment {
    DOCKER_IMAGE = 'tiagoggdev/creditapplication'
    DOCKER_TAG = 'latest'
  }

  stages {
    stage('Checkout') {
      steps {
        checkout scm
      }
    }
    stage('Restore & Build') {
      steps {
        sh 'dotnet restore CreditApplication.sln'
        sh 'dotnet build CreditApplication.sln -c Release'
      }
    }
    stage('Publish') {
      steps {
        sh 'dotnet publish CreditApplication.API/CreditApplication.API.csproj -c Release -o out'
      }
    }
    stage('Docker Build & Push') {
      steps {
        sh "docker build -t ${DOCKER_IMAGE}:${DOCKER_TAG} ."
        sh "docker tag ${DOCKER_IMAGE}:${DOCKER_TAG} ${DOCKER_IMAGE}:${DOCKER_TAG}"
        // Opcional: push si ya agregaste credenciales en Jenkins
        // sh "docker push ${DOCKER_IMAGE}:${DOCKER_TAG}"
      }
    }
  }

  post {
    success {
      echo '✅ Build exitoso y lista imagen Docker'
    }
    failure {
      echo '❌ Falló el pipeline'
    }
  }
}
