# 🎯 Heads War – AR Shooter Game  

**Heads War** est un jeu mobile en **réalité augmentée (AR)** où l'objectif est d'éliminer un maximum d'ennemis dans un **temps imparti**. Grâce à la **reconnaissance d'image**, les ennemis apparaissent dans l'environnement du joueur, créant une expérience immersive et interactive.  

## 🚀 Fonctionnalités principales  
- 📱 **Réalité Augmentée** : Les ennemis apparaissent dans le monde réel grâce à la reconnaissance d'image.  
- 🎯 **Gameplay dynamique** :  
  - Éliminez le plus d'ennemis possible avant la fin du chrono.  
  - **Système de tir** basé sur un `FirePoint` (inspiré de *The Last Guardian*).  
  - **Gestion des collisions** entre balles et drones avec `WireSphere`.  
  - **Les drones attaquent** et explosent à l'impact (*style Tower Defense*).  
- 🔥 **Progression et défis** :  
  - Système de **NameTag** dans les paramètres.  
  - Niveaux basés sur un **timer** et un changement d'orientation.  

## 🖥 Interface Utilisateur (UI)  
- 🏆 **Affichage des points du joueur**.  
- ❤️ **Timer** en haut au milieu.  
- ⏸ **Écrans interactifs** : Pause, Game Over et Level Won (avec animations).  

## 🛠 Technologies utilisées  
- **Unity** avec **AR Foundation**  
- **C#** pour la programmation  
- **Vuforia / ARKit / ARCore** *(selon la plateforme ciblée)*  

## 🎮 Mécaniques de Jeu  
- **Système de tir** :  
  - Les balles partent du `FirePoint` et avancent en ligne droite.  
  - Destruction de la balle à l'impact ou après une certaine distance.  
  - Recherche en cours pour un tir en **cloche**.  
- **Drones ennemis** :  
  - Se déplacent vers le bas et explosent à l'impact.  
  - Peuvent **tirer sur le joueur**.  
  - Déplacement géré par un **script externe**.  

## 📌 Installation  
1. **Cloner le projet**  
   ```sh
   git clone https://github.com/tonprofil/HeadsWar.git
   ```
2. **Ouvrir avec Unity** (version recommandée : *exemple Unity 2022.3 LTS*)  
3. **Configurer le support AR** (ARCore pour Android)  
4. **Lancer sur un appareil mobile** 🎮  

## 🛠 Améliorations et roadmap  
🔜 À venir :  
- ✅ Ajustements du tir (direction unique ou en cloche).  
- ✅ Système de spawn dynamique : clonage d’objets à **15 unités** du joueur.  
- 🎵 Effets sonores et musique.  
- 📡 Mode multijoueur *(potentiellement à explorer !)*.
- Trois niveaux de difficulté : **Easy, Medium, Hard** *(potentiellement à explorer !)*.   

## 📣 Contributions  
Le projet est en développement, toute suggestion est la bienvenue ! 🛠  

📩 **Contact** : https://www.linkedin.com/in/marco-tomba-574b042b7/
