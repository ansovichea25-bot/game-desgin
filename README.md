# AR-Face-Tracking-Filter-App-in-Unity
Developed my first face tracking filter application for android phones using unity. It detects and tracks the face to display custom digital content on it.<br>
Use on unity version 2022.3.10f1 and above.

## New Custom AR Filter Features
- Added an editor overlay UI with a `Next Filter` button and an `Auto Cycle` toggle.
- Added a new reskin tint effect for spawned filter props so filters look more polished during demos.
- Supports automatic filter switching every few seconds for faster feature demos.

## Demo Instructions
1. Open `Assets/Scenes/ARFaceFilter.unity` in Unity 2022.3.x.
2. Select the `EditorArFaceSchoolDemo` object and verify the inspector has:
   - `AR Default Face Prefab`
   - `Filter Prefabs`
   - `Video Backdrop Source` (if using webcam or scene video)
3. Press `Play` to start the editor demo.
4. Use the fullscreen overlay buttons during Play mode:
   - `Next Filter` to manually cycle filter props.
   - `Auto Cycle` to toggle automatic filter switching.
5. Record the demo using a screen recorder:
   - Windows Game Bar: press `Win + Alt + R`
   - OBS Studio: capture the Unity Game window
   - Unity Recorder: if installed, record directly from the Game view
6. If you want a demo video source, use a short selfie clip from your phone or a free sample clip from sites like Pexels, Pixabay, or Mixkit.

# Steps-to-Add-Custom-Video:
# Step-0:
  a) Make sure to have all the pre-requisites such as android SDK & NDK installed in unity. <br>
  b) Download the repository as zip file or paste the git-url in the package manager inside unity.<br>
  
# Step-1:
  a) Download the video of your choice.<br>
  b) Paste it in the assets folder inside unity.<br>
  c) Single click on the video and make the following changes to remove the time stamp error if it comes in the console window:<br>
      &nbsp; &nbsp;  a. Look in the inspector window after single-clicking on the video file.<br>
      &nbsp; &nbsp;  b. Inside the sRGB(color texture) tab, after pressing on the android version, change the codec to VP8 and apply the changes.<br>
  d) Click on the VideoPlayer object in the hierarchy window.<br>
  e) Drag and drop the video from assets to the Video-clip section inside the Videoplayer tab inside the inspector window.<br>

# Step-2:
  a) Go to File -> Build Settings.<br>
  b) Press on Add open scenes to add the AR Filter scene inside the the scene build hierarchy.<br>
  c) Finally Build/Build and run.<br>
