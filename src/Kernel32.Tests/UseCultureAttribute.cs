// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using Xunit.Sdk;

/// <summary>
/// Apply this attribute to your test method to replace the
/// Thread.CurrentThread <see cref="CultureInfo.CurrentCulture" /> and
/// <see cref="CultureInfo.CurrentUICulture" /> with another culture.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
internal class UseCultureAttribute : BeforeAfterTestAttribute
{
    private readonly CultureInfo culture;
    private readonly CultureInfo uiCulture;

    private CultureInfo originalCulture;
    private CultureInfo originalUICulture;

    /// <summary>
    /// Initializes a new instance of the <see cref="UseCultureAttribute"/> class.
    /// It replaces the culture and UI culture of the current thread with the one specified in  <paramref name="culture" />.
    /// </summary>
    /// <param name="culture">The name of the culture.</param>
    /// <remarks>
    /// <para>
    /// This constructor overload uses <paramref name="culture" /> for both
    /// <see cref="Culture" /> and <see cref="UICulture" />.
    /// </para>
    /// </remarks>
    public UseCultureAttribute(string culture)
        : this(culture, culture)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UseCultureAttribute"/> class.
    /// It replaces the culture and UI culture of the current thread with the ones specified in <paramref name="culture" /> and <paramref name="uiCulture" />.
    /// </summary>
    /// <param name="culture">The name of the culture.</param>
    /// <param name="uiCulture">The name of the UI culture.</param>
    public UseCultureAttribute(string culture, string uiCulture)
    {
        this.culture = new CultureInfo(culture);
        this.uiCulture = new CultureInfo(uiCulture);
    }

    /// <summary>
    /// Gets the culture that will be set by this attribute
    /// </summary>
    public CultureInfo Culture => this.culture;

    /// <summary>
    /// Gets the UI culture that will be set by this attribute
    /// </summary>
    public CultureInfo UICulture => this.uiCulture;

    /// <summary>
    /// Stores the current Thread.CurrentPrincipal
    /// <see cref="CultureInfo.CurrentCulture" /> and <see cref="CultureInfo.CurrentUICulture" />
    /// and replaces them with the new cultures defined in the constructor.
    /// </summary>
    /// <param name="methodUnderTest">The method under test</param>
    public override void Before(MethodInfo methodUnderTest)
    {
        this.originalCulture = CultureInfo.CurrentCulture;
        this.originalUICulture = CultureInfo.CurrentUICulture;

#if DESKTOP
        Thread.CurrentThread.CurrentCulture = this.Culture;
        Thread.CurrentThread.CurrentUICulture = this.UICulture;
#else
        CultureInfo.DefaultThreadCurrentCulture = this.Culture;
        CultureInfo.DefaultThreadCurrentUICulture = this.UICulture;
#endif
    }

    /// <summary>
    /// Restores the original <see cref="CultureInfo.CurrentCulture" /> and
    /// <see cref="CultureInfo.CurrentUICulture" /> to Thread.CurrentPrincipal />
    /// </summary>
    /// <param name="methodUnderTest">The method under test</param>
    public override void After(MethodInfo methodUnderTest)
    {
#if DESKTOP
        Thread.CurrentThread.CurrentCulture = this.originalCulture;
        Thread.CurrentThread.CurrentUICulture = this.originalUICulture;
#else
        CultureInfo.DefaultThreadCurrentCulture = this.originalCulture;
        CultureInfo.DefaultThreadCurrentUICulture = this.originalUICulture;
#endif
    }
}
