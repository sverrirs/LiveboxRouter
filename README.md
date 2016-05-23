<p align="center">
  <img src="https://raw.githubusercontent.com/sverrirs/LiveboxRouter/master/src/LiveboxRouter/img/livebox-play.png" />
</p>

# LiveboxRouter
Provides a .NET library functions to connect to and control a Livebox 3 router from Sagemcom. This router is used for internet services offered by Orange in France, UK, Spain, Netherlands, Switzerland, Poland and other countries.

<a href="https://en.wikipedia.org/wiki/Orange_Livebox" target="_blank">Wikipedia</a>

# Features
The library is in its early stages and built simply so that I could automate Firewall tasks when using DNS blocking services such as Unlocator.
The following features have been implemented:
* Login
* Get Device Info
* Get/Set Firewall levels
* Get Firewall custom rules
* Getting WAN network status

Todo:
* Set Firewall custom rules (create new IP blocking rules)

# Functionality
The test application that comes with the `LiveboxAdapter.cs` class (which is the main library file) is very simple.
After typing in the username and password to your router you can press connect to verify that the application can connect to your LAN router. After the first time this is done the application will establish the connection automatically when started.

The app will indicate the current status of your router's firewall to indicate if the DNS block is in place or not. 

<p align="center">
  <img src="https://raw.githubusercontent.com/sverrirs/LiveboxRouter/master/src/LiveboxRouter/img/screenshot01.png" />
</p>

You can then simply click the Enable block or disable block button to apply the necessary settings to your router.

_Note: Currently the app only either applies the normal or custom firewall settings when the buttons are pressed. You can set up your custom rules by hand and then this will work for the time being. In the future I will add functionality to automatically create all the DNS blocking entries based on your DNS provider settings._

# Examples
To obtain information about the device

``` csharp
LiveboxAdapter a = new LiveboxAdapter(username, password);
a.LoginAsync().OnSuccess((t, o) =>
{
  a.GetDeviceInfo().OnSuccess((t2, o2) =>
  {
    var res = t2.Result;
    // the res object is a typed device info object
  }
});
```

Setting the firewall level to **medium**

``` csharp
LiveboxAdapter a = new LiveboxAdapter(username, password);
a.LoginAsync().OnSuccess((t, o) =>
{
  a.SetFirewallToMedium().OnSuccess((t2, o2) =>
  {
      var res = t2.Result;
      if (!res.Status.GetValueOrDefault())
      {
          textbox.Text = "Error: " + res.Errors.First().Description;
      }
      else
      {
          textbox.Text = "Success: " + res.Status;
      }
  }, _uiScheduler);
});
```

<p align="center">
  <img src="https://raw.githubusercontent.com/sverrirs/LiveboxRouter/master/src/LiveboxRouter/img/livebox_icon.png" width="200" />
</p>

