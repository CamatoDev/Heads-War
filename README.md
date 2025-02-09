# 🎯 Heads War – AR Shooter Game  

**Heads War** est un jeu mobile en **réalité augmentée (AR)** où l'objectif est d'éliminer un maximum d'ennemis dans un **temps imparti**. Grâce à la **reconnaissance d'image**, les ennemis apparaissent dans l'environnement du joueur, créant une expérience immersive et interactive.  

🚀 **Le jeu est désormais en version jouable !** 🚀  

---

## 🚀 Fonctionnalités principales  

- 📱 **Réalité Augmentée** : Les ennemis apparaissent dans le monde réel grâce à la reconnaissance d'image.  
- 🎯 **Gameplay dynamique** :  
  - Éliminez le plus d'ennemis possible avant la fin du chrono.  
  - **Système de tir** basé sur un `FirePoint`.  
  - **Gestion des collisions** entre balles et drones avec `WireSphere`.  
  - **Les drones se déplacent** et explosent à l'impact des balles.  
- 🔥 **Progression et défis** :  
  - Système de **NameTag** dans les paramètres.  
  - Niveaux basés sur un **timer**.  

---

## 🖥 Interface Utilisateur (UI)  

- 🏆 **Affichage des points du joueur**.  
- ❤️ **Barre de vie visible en haut à gauche**.  
- ⏳ **Timer en haut au milieu**.  
- ⏸ **Écrans interactifs** : Pause, Game Over et Level Won (avec animations).  

---

## 🛠 Technologies utilisées  

- **Unity** avec **AR Foundation**  
- **C#** pour la programmation  
- **Vuforia / ARKit / ARCore** *(selon la plateforme ciblée)*  

---

## 🎮 Mécaniques de Jeu  

- **Système de tir** :  
  - Les balles partent du `FirePoint` et avancent en ligne droite.  
  - **Destruction des balles** à l'impact ou après une certaine distance.  
  - **Tir ajusté** pour une **direction unique** (recherche sur le tir en cloche complétée).  
  - **Bouton Shoot** instanciant les balles avec un temps de désactivation pour la cadence de tir (*inspiré de The Last Guardian*).  
- **Drones ennemis** :  
  - Se déplacent dynamiquement avec un **système de déplacement** intégré.  
  - **Clonage d'ennemis** à une distance dynamique de **15 unités** du joueur.

---

## 📌 Installation  

1. **Cloner le projet**  
   ```sh
   git clone https://github.com/tonprofil/HeadsWar.git
   ```
2. **Ouvrir avec Unity** (version recommandée : *Unity 2022.3 LTS*)  
3. **Configurer le support AR** (*ARCore pour Android)  
4. **Lancer sur un appareil mobile** 🎮  

---

## 🎯 Améliorations récentes  

- ✅ **Système de tir en direction unique finalisé**.  
- ✅ **Système de spawn dynamique** : clonage d’objets à **40 unités** du joueur.  
- ✅ **Ajout des effets sonores et de la musique**.  
- ✅ **Ajout du déplacement automatique des drones**.  
- ✅ **Interface améliorée avec affichage des points et barre de vie**.  

---

## 🔜 Roadmap  

- 📡 **Mode multijoueur** *(potentiellement à explorer !)*.  
- 🎨 **Ajout de nouveaux modèles 3D et animations d’ennemis**.  
- 🎮 **Optimisation de la jouabilité et équilibrage des niveaux**.
- **Trois niveaux de difficulté** : **Easy, Medium, Hard**.  

---

## 📣 Contributions  

Le projet est en développement, toute suggestion est la bienvenue ! 🛠  

📩 **Contact** : https://www.linkedin.com/in/marco-tomba-574b042b7/

---

🎮 **Prêt à affronter les ennemis en AR ? Télécharge Heads War et plonge dans l'action !** 🚀  
