using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCross.Exceptions;
using MvvmCross.Commands;

namespace PhotoMagazine.Client.Core.ViewModels
{
    public class BaseViewModel: MvxViewModel
    {
        public BaseViewModel()
        {
            NavigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();

            if (NavigationService == null)
            {
                throw new MvxException($"{nameof(NavigationService)} can not resolve.");
            }
        }

        public string AlertMessage { get; set; }
        public bool ValidateStatus { get; set; }

        public IMvxNavigationService NavigationService { get; protected set; }
        public virtual MvxAsyncCommand DisposeCommandAsync => new MvxAsyncCommand(async () => await NavigationService.Close(this));
    }

    public abstract class BaseViewModel<TModel> : BaseViewModel, IMvxViewModel<TModel>, IMvxViewModel
    {
        public abstract void Prepare(TModel parameter);
    }

    public abstract class BaseViewModel<TModel, TResult> : BaseViewModel, IMvxViewModel<TModel, TResult>
    {
        public override MvxAsyncCommand DisposeCommandAsync => new MvxAsyncCommand(async () =>
        {
            await NavigationService.Close(this, Result);
        });

        public TResult Result { get; set; }

        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (viewFinishing && CloseCompletionSource != null && !CloseCompletionSource.Task.IsCompleted && !CloseCompletionSource.Task.IsFaulted)
                CloseCompletionSource?.TrySetCanceled();

            base.ViewDestroy(viewFinishing);
        }

        public abstract void Prepare(TModel parameter);
    }
}
