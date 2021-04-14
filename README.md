# This repo is part of a bachelor thesis in multimedia & communication. The project is only in a test state, provided to give some insight into the current status of immersive and interactive Mobile AR in Unitys ARFoundation with ARCore. The repo is based on the following demo, provided by Unity Technologies.
For questions please reach out via Github.

# This repo is intended to provide more advanced demos for AR Foundation outside of the [Samples Repo](https://github.com/Unity-Technologies/arfoundation-samples/).
For questions and issues related to AR Foundation please post on the AR Foundation Sample [issues](https://github.com/Unity-Technologies/arfoundation-samples/issues) and **NOT** in this repo. You can also post on the [AR Foundation Forums](https://forum.unity.com/forums/ar.161/)

  


# arfoundation-demos
AR Foundation demo projects.

Demo projects that use [*AR Foundation 4.1*](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.1/manual/index.html) and demonstrate more advanced functionality around certain features

This set of demos relies on five Unity packages:

* ARSubsystems ([documentation](https://docs.unity3d.com/Packages/com.unity.xr.arsubsystems@3.0/manual/index.html))
* ARCore XR Plugin ([documentation](https://docs.unity3d.com/Packages/com.unity.xr.arcore@3.0/manual/index.html))
* ARKit XR Plugin ([documentation](https://docs.unity3d.com/Packages/com.unity.xr.arkit@3.0/manual/index.html))
* ARKit Face Tracking ([documentation](https://docs.unity3d.com/Packages/com.unity.xr.arkit-face-tracking@3.0/manual/index.html))
* ARFoundation ([documentation](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@3.0/manual/index.html))

[Onboarding UX](#ux--also-available-on-the-asset-store-here) 
------------ | ------------- | ------------- | ----------------

## The UX/UI of the test app is based on the UX example provided by Unity Technologies:
  
UX — Also available on the asset store [here](https://assetstore.unity.com/packages/templates/ar-foundation-demos-onboarding-ux-164766)

![img](https://user-images.githubusercontent.com/2120584/87749152-b8fb4a00-c7ac-11ea-807c-0e04325f69da.png)

A UI / UX framework for providing guidance to the user for a variety of different types of mobile AR apps. 

The framework adopts the idea of having instructional UI shown with an instructional goal in mind. One common use of this is UI instructing the user to move their device around with the goal of the user to find a plane. Once the goal is reached the UI fades out. There is also a secondary instruction UI and an API that allows developers to add any number of additional UI and goals that will go into a queue and be processed one at a time.

A common two step UI / Goal is to instruct the user to find a plane. Once a plane is found you can instruct the user to tap in order to place an object. Once an object is placed fade out the UI.

![img](https://user-images.githubusercontent.com/2120584/87749208-e2b47100-c7ac-11ea-93ef-5955e2a541b1.png)


The goals are checking the associated `ARTrackableManager` number of trackables count. One thing to note is this is just looking for a trackable to be added, it does not check the tracking state of said trackable.

The script [`UIManager.cs`](https://github.com/Unity-Technologies/arfoundation-demos/blob/master/Assets/UX/Scripts/UIManager.cs) is used to configure the Instructional Goals, secondary instructional goals and holds references to the different trackable managers.

UIManager manages a [queue](https://github.com/Unity-Technologies/arfoundation-demos/blob/master/Assets/UX/Scripts/UIManager.cs#L120) of [`UXHandle`](https://github.com/Unity-Technologies/arfoundation-demos/blob/master/Assets/UX/Scripts/UIManager.cs#L6-L16) which allows any instructional UI with any goal to be dynamically added at runtime. To do this you can store a reference to the UIManager and call [`AddToQueue()`](https://github.com/Unity-Technologies/arfoundation-demos/blob/master/Assets/UX/Scripts/UIManager.cs#L374-L377) passing in a UXHandle object. For testing purposes to visualize every UI video I use the following setup.

```
m_UIManager = GetComponent<UIManager>();      
m_UIManager.AddToQueue(new UXHandle(UIManager.InstructionUI.CrossPlatformFindAPlane, UIManager.InstructionGoals.PlacedAnObject));
m_UIManager.AddToQueue(new UXHandle(UIManager.InstructionUI.FindABody, UIManager.InstructionGoals.PlacedAnObject));
m_UIManager.AddToQueue(new UXHandle(UIManager.InstructionUI.FindAFace, UIManager.InstructionGoals.PlacedAnObject));
m_UIManager.AddToQueue(new UXHandle(UIManager.InstructionUI.FindAnImage, UIManager.InstructionGoals.PlacedAnObject));
m_UIManager.AddToQueue(new UXHandle(UIManager.InstructionUI.FindAnObject, UIManager.InstructionGoals.PlacedAnObject));
m_UIManager.AddToQueue(new UXHandle(UIManager.InstructionUI.ARKitCoachingOverlay, UIManager.InstructionGoals.PlacedAnObject));
```
