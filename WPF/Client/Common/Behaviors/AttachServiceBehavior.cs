using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Mvvm.UI;
using System.Windows;

namespace Client.Common.Behaviors;

public class AttachServiceBehavior : Behavior<DependencyObject>
{
    public static readonly DependencyProperty AtachableServiceProperty =
        DependencyProperty.Register(nameof(AtachableService), typeof(ServiceBase), typeof(AttachServiceBehavior), new PropertyMetadata(null, OnAtachableServiceChanged));

    static void OnAtachableServiceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (e.OldValue as ServiceBase)?.Detach();
        ((AttachServiceBehavior)d).AttachService();
    }

    public ServiceBase AtachableService
    {
        get => (ServiceBase)GetValue(AtachableServiceProperty);
        set => SetValue(AtachableServiceProperty, value);
    }

    protected override void OnAttached()
    {
        base.OnAttached();
        AttachService();
    }
    protected override void OnDetaching()
    {
        base.OnDetaching();
        AtachableService?.Detach();
    }

    void AttachService()
    {
        if (AtachableService == null || AssociatedObject == null)
            return;
        if (AtachableService.IsAttached)
            AtachableService.Detach();
        AtachableService.Attach(AssociatedObject);
    }
}