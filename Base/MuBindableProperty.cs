using System;

namespace MuUI
{
	public enum BindDirection { None, Get, Set, Both };
	
	public class BindableProperty<TOwner, TProperty> : IDisposable
	{
		private TOwner _owner;
		private TProperty _property;
		private Func<TProperty> _getter;
		private Action<TProperty> _setter;
		
		public BindableProperty(TOwner owner)
		{
			_owner = owner;
		}
		
		public BindableProperty(TOwner owner, TProperty defaultProperty) : this(owner)
		{
			_property = defaultProperty;
		}
		
		public TOwner BindGet(Func<TProperty> getter)
		{
			_getter = getter;
			return _owner;
		}
		
		public TOwner BindSet(Action<TProperty> setter)
		{
			_setter = setter;
			return _owner;
		}
		
		public TOwner BindBoth(Func<TProperty> getter, Action<TProperty> setter)
		{
			_getter = getter;
			_setter = setter;
			return _owner;
		}
		
		public event Action<TOwner, TProperty, TProperty> PropertyChanged = delegate{};
		
		public TOwner OnPropertyChanged(Action<TOwner, TProperty, TProperty> changed)
		{
			PropertyChanged += changed;
			return _owner;
		}
		
		internal TOwner SetValueWithoutBinding(TProperty val)
		{
			_property = val;
			return _owner;
		}
		
		public TProperty Value
		{
			get
			{
				PerformGet();
				return _property;
			}
			set
			{
				PerformSet(value);
			}
		}
		
		private void PerformGet()
		{
			var dir = Direction;
			if (dir == BindDirection.Get || dir == BindDirection.Both)
			{
				var val = _getter();
				if (AreDifferent(_property, val))
				{
					PropertyChanged(_owner, _property, val);
				}
				_property = val;
			}
		}
		
		private void PerformSet(TProperty val)
		{
			if (AreDifferent(_property, val))
			{
				PropertyChanged(_owner, _property, val);
			}
			var dir = Direction;
			if (dir == BindDirection.Set || dir == BindDirection.Both)
			{
				_setter(val);
			}
			_property = val;
		}
		
		public BindDirection Direction
		{
			get
			{
				if (_getter != null)
				{
					if (_setter != null)
					{
						return BindDirection.Both;
					}
					return BindDirection.Get;
				}
				if (_setter != null)
				{
					return BindDirection.Set;
				}
				return BindDirection.None;
			}
		}
		
		public void Dispose()
		{
			_owner = default(TOwner);
			_getter = null;
			_setter = null;
		}
		
		private bool AreDifferent(Object a, Object b)
		{
			if (a == null && b == null)
			{
				return false;
			}
			if ((a == null && b != null) || (a != null && b == null))
			{
				return true;
			}
			return !a.Equals(b);
		}
	}
}

