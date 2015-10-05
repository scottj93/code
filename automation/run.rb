module Automation
  class Run < Thor
    include ::Automation::InputUtils
    namespace :run

    desc 'feature', 'runs a feature'
    def feature
      feature = pick_item_from(settings.features, "Which feature?")
      url = "#{feature}"
      the_url(url)
    end

    desc 'the_url', 'runs a url'
    def the_url(url)
      url = "http://localhost:#{settings.iis_express.port}/#{url}"
      system("start #{settings.browser} #{url}")
    end
  end
end
