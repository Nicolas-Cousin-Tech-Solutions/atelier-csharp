# Démarrer datalust/seq avec Docker

Cette section décrit comment démarrer le conteneur Docker de datalust/seq.

## Étapes

1. **Récupérer l'image Docker**
    ```bash
    docker pull datalust/seq:latest
    ```

2. **Démarrer le conteneur**
    ```bash
    docker run --name seq -d \
      --restart unless-stopped \
      -e ACCEPT_EULA=Y \
      -p 5341:5341 \
      datalust/seq:latest
    ```

    - L'option `--name seq` donne un nom au conteneur.
    - `-d` lance le conteneur en mode détaché.
    - `--restart unless-stopped` permet de redémarrer automatiquement le conteneur.
    - `-e ACCEPT_EULA=Y` accepte la licence utilisateur finale.
    - `-p 80:80` et `-p 5341:5341` publient les ports nécessaires.

3. **Vérifier que le conteneur fonctionne**
    ```bash
    docker ps
    ```

    Vous devriez voir le conteneur `seq` en cours d'exécution.
