﻿namespace CardholderManagementSystem.DTOs
{
    public sealed class PagedResponse<T>
    {
        public IReadOnlyList<T> Items { get; init; } = Array.Empty<T>();
        public int Page { get; init; }
        public int PageSize { get; init; }
        public int TotalCount { get; init; }
        public int TotalPages { get; init; }
        public bool HasNext => Page < TotalPages;
        public bool HasPrevious => Page > 1;
    }
}
