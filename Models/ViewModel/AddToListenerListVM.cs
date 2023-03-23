﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicApplication.Models.ViewModel
{
    public class AddToListenerListVM
    {
        public HashSet<SelectListItem> ListenerLists { get; set; } = new HashSet<SelectListItem>();

        public int? PodcastId { get; set; }
        public string? PodcastTitle { get; set; }

        public int? ListenerListId { get; set; }

        public string? ViewMessage { get; set; }
        public void PopulateList(IEnumerable<ListenerList> listenerLists)
        {
            foreach (ListenerList l in listenerLists)
            {
                ListenerLists.Add(new SelectListItem($"{l.Name}", l.Id.ToString()));
            }
        }

        public AddToListenerListVM() { }
        public AddToListenerListVM(IEnumerable<ListenerList> listenerLists, int podcastId, string podcastTitle)
        {
            PopulateList(listenerLists);
            PodcastId = podcastId;
            PodcastId = podcastId;
        }
    }
}
