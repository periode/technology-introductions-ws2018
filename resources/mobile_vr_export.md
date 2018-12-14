# Unity

1. Download [Unity](https://unity3d.com/get-unity/download?ref=personal), version 2018.2 at the beginning of the 2018 Winter semester. Click on *Download Installer*. Once the installer is downloaded, open it. If you're on Linux, go at the bottom of [this page](https://forum.unity.com/threads/unity-on-linux-release-notes-and-known-issues.350256/page-2)

2. When prompted which components you should install, *make sure to tick the platform you will develop for* (i.e. Android Build Support and/or iOS Build Support and/or Mac Build Support)

![Unity Components Installation](https://github.com/pierredepaz/alternate-realities/blob/master/assets/img/unity_modules.png)

---

# Android

1. Downloading and installing Unity with the Android Build Support **is not enough**. You need to install Android-specific software too.

2. Start by downloading [the latest JDK](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html) (JDK 8 at the beginning of the semester). Install it **and remember where you install it**.

3. Then, download [Android Studio](https://developer.android.com/studio/index.html). Android Studio is the easiest way to install the Android SDK. Go through all of the installation steps with the default settings.

4. Once you've installed the Android SDK, open it and go to **Preferences (or Settings) > Appearance > System Settings > Android SDK**. At the top of the list, click the **SDK Tools** tab. Tick the checkboxes for **Build-Tools, Platform-Tools** and **SDK Tools**.

![Installing Components](https://github.com/pierredepaz/alternate-realities/blob/master/assets/img/android_sdk.png)

4b. Notice that, at the top of the Android SDK Window, there is the Android SDK location, something like `/Users/YOURNAME/Library/Android/sdk`. Unity will ask you for it in the next step.

5. Next time you build a project in Unity for Android, it will ask you to locate the JDK and the Android SDK. Browse to the install location and select the respective install folders.

6. For the rest of the export, it happens in Unity.

---

# iOS

1. Download and install [XCode](https://developer.apple.com/xcode/), which will allow Unity to communicate to your iPhone. Sign in to XCode with your Apple ID, which should be automatically linked to a Personal Developer Account.

2. Go to **XCode > Preferences > Accounts > Apple IDs**, click on your Apple ID and make sure that you are logged in.

---

# Test a Mobile VR Project

1. Download the Cardboard SDK from [here](https://github.com/googlevr/gvr-unity-sdk/releases)

2. Open Unity and create a new 3D project.

3. Click on `Assets > Import Package... > Custom Package`.

4. Navigate to the folder where you've downloaded the Google VR SDK from step 1 and open `GoogleVRForUnity_1.xxx.unitypackage`.

5. In the pop-up window, leave everything checked and click `Import`. Now, all of the files should be in a folder called `GoogleVR`.

6. Open `GoogleVR > Demos > Scenes > HelloVR.unity`. Click the play button and look around!

---

# Build Settings

1. Now that we've installed all necessary software in order to build on Android or Unity, there are a few settings we need to look at before launching the build. In Unity, select **File > Build Settings**.

2. In the bottom left list, select the platform you want to build for (Android, iOS, Desktop), and click on **Switch Platforms**. The current platform is the one with the Unity Logo next to it. It might take some time to switch from one platform to another.

3. Whether you've clicked Android or iOS, make sure that you **check the Development Build** tickbox.

3. Then, at the bottom of the Build window, click on **Player Settings**. At the very top, change *Company Name* and *Product Name* to something unique (i.e. *com.TheName.TheFirstTest*). This will only be public if you decide to put your VR app on the Play Store or on the App Store.

5. In **Other Settings**, change the **Bundle Identifier** so that it matches the Company Name and Product Name that you've chosen at the beginning (which would be, in our case, *com.TheName.TheFirstTest*).

6. For Android, set the **Minimum API Level** to **19** (Android 4.4 KitKat). For iOS, set **Target Minimum iOS Version** to **7.0**.

7. In **XR Settings**, check *Virtual Reality Supported*, and then select in the list **Cardboard**.

![Installing Components](https://github.com/periode/technology-introductions-ws2018/blob/master/resources/img/xr_settings.png)

8. Done! If you're developing for Android, make sure your phone is connected in [USB debugging mode](https://www.kingoapp.com/root-tutorials/how-to-enable-usb-debugging-mode-on-android.htm), then click *Build and Run**. On Android, your app should run directly on your phone! On iOS, a folder should open... Go to the next section.

---

# iOS part 2

1. Once you've built a project with Unity, Unity will generate an XCode project folder. If XCode doesn't launch automatically, you will then need to open the `.xworkspace` file, in that generated folder.

2. Click on the blue icon named `Unity-iPhone` on the left panel. In the **Identity** section, make sure your **Bundle Identifier** is set to something *different* than the default com.CompanyName.Product.

3. In the **Signing** section, enable **Automatically manage signing**, and in the dropdown menu choose your Personal Team.

![Choosing a personal team in XCode](https://github.com/periode/technology-introductions-ws2018/blob/master/resources/img/xcode_signing.png)

4. Finally, in the top left, next to the Stop Button, select your target device (*you need to have your iPhone connected and trusting your computer!*)

![Choosing target device](https://github.com/periode/technology-introductions-ws2018/blob/master/resources/img/selecting_target.png)

5. Press the Play button at the top left, and the VR app should launch on the device!
