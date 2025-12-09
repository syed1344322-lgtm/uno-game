# UnoPlus - Unity Project Skeleton (Text-only)

This repository is a text-only Unity project skeleton created by ChatGPT.
It contains scripts for a minimal UNO-style game plus social features (clubs, tournaments, leaderboards),
a build script to produce an Android App Bundle (.aab) via Unity CLI, and a GitHub Actions workflow to build the AAB.

## How to use

1. Download and unzip this project.
2. Open the folder in Unity 2022.3 LTS (recommended).
3. Import required SDKs (Photon PUN or Fusion, PlayFab SDK) via Package Manager / Asset Store.
4. In Unity: Player Settings -> Other Settings:
   - Set Package Name (e.g., com.yourcompany.unoplus)
   - Set Target API Level as required by Google Play
5. Add your keystore in Player Settings -> Publishing Settings.
6. Commit to GitHub `main` to trigger the CI build (workflow uses Unity 2022.3.29f1).
7. Download the produced `.aab` artifact from GitHub Actions.

## Notes

- This skeleton contains only code and minimal scene; add your UI, art, audio, and SDK configuration.
- Do not store your keystore or Play service account JSON in public repos.
- For Play Store upload automation, add a second job using `r0adkll/upload-google-play` and store
  your service account JSON in GitHub Secrets.
