# SkiaSharp 中文字体问题

## SkiaSharp

SkiaSharp是基于Google的Skia图形库（[skia.org](https://skia.org/)）的.NET平台的跨平台2D图形API 。它提供了全面的2D API，可在移动，服务器和台式机模型之间使用以渲染图像。

SkiaSharp为以下内容提供跨平台绑定：

* .NET标准1.3
* .NET核心
* 提岑
* Xamarin.Android
* Xamarin.iOS
* Xamarin.tvOS
* Xamarin.watchOS
* Xamarin.Mac
* Windows经典桌面（Windows.Forms / WPF）
* Windows UWP（台式机/移动/ Xbox / HoloLens）
* Web汇编（WASM）

该[API文档](https://docs.microsoft.com/en-us/dotnet/api/SkiaSharp/)可在以下网站上浏览。

[源码地址](https://github.com/mono/SkiaSharp)

## `SKTypeface.FromFamilyName`获取中文字体

* 操作系统WIN8
* 目标框架.Net Framework4.7.2

```C#
var stypeface = SKTypeface.FromFamilyName("宋体");
```

通过该方法无法正确获取宋体。获取到的为SkiaSharp默认的字体：

```txt
{SkiaSharp.SKTypeface.SKTypefaceStatic}
    FamilyName: "Segoe UI"
    FontSlant: Upright
    FontStyle: {SkiaSharp.SKFontStyle}
    FontWeight: 400
    FontWidth: 5
    GlyphCount: 5012
    Handle: 0x05112170
    IgnorePublicDispose: true
    IsBold: false
    IsDisposed: false
    IsFixedPitch: false
    IsItalic: false
    OwnsHandle: true
    Style: Normal
    TableCount: 23
    UnitsPerEm: 2048
```

图片中的中文为口子方块:

![图片中的中文为口子方块](Images/图片中的中文为口子方块.png)

## 解决方法

使用`SKFontManager`类来获取中文字体，代码如下：

```C#
// 获取宋体在字体集合中的下标
var index = SKFontManager.Default.FontFamilies.ToList().IndexOf("宋体");
// 创建宋体字形
var songtiTypeface = SKFontManager.Default.GetFontStyles(index).CreateTypeface(0);
```

获取到正确的中文字体：

```txt
{SkiaSharp.SKTypeface}
    FamilyName: "SimSun"
    FontSlant: Upright
    FontStyle: {SkiaSharp.SKFontStyle}
    FontWeight: 400
    FontWidth: 5
    GlyphCount: 28762
    Handle: 0x060aace0
    IgnorePublicDispose: true
    IsBold: false
    IsDisposed: false
    IsFixedPitch: false
    IsItalic: false
    OwnsHandle: true
    Style: Normal
    TableCount: 22
    UnitsPerEm: 256
```

图片中的中文正确显示：

![图片中的中文正确显示](Images/图片中的中文正确显示.png)

也可以直接使用`SKTypeface.FromFamilyName("SimSun")`获取中文字体
