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

<p align="center">
  <img src="https://raw.githubusercontent.com/sverrirs/LiveboxRouter/master/src/LiveboxRouter/img/livebox_icon.png" width="200" />
</p>

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

